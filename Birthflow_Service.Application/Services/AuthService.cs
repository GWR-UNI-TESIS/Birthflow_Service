using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Domain.Interface;
using Birthflow_Service.Application.Models;
using BirthflowMicroServices.Domain.Models;
using BirthflowService.Application.Interfaces;
using BirthflowService.Application.Models;
using BirthflowService.Domain.DTOs.Contracts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using BirthflowService.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace Birthflow_Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMailAdapter _mailService;

        public AuthService(IConfiguration configuration, ILogger<AuthService> logger, IUserRepository userRepository, IAuthRepository authRepository, IMailAdapter mailService, IAccountRepository accountRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _authRepository = authRepository;
            _mailService = mailService;
            _logger = logger;
            _accountRepository = accountRepository;
        }

        private string CreateToken(UserEntity user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Nombres", user.Name),
                new Claim("Apellidos", user.SecondName),
                new Claim("NombreUsuario", user.UserName),
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        public BaseResponse<UserLoginDto> Login(LoginModel request)
        {
            UserEntity? user;

            user = _userRepository.GetByUserName(request.Email);
            if (user is null)
                user = _userRepository.GetByEmail(request.Email);

            if (user is null)
                return new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "User not found.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };

            if (user.IsDelete)
                return new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };

            if (user.UserName != request.Email && user.Email != request.Email)
            {
                return new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "User not found.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }

            if (!VefiryPassword(request.Password, user.PasswordHash))
            {
                return new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "Invalid Credential.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }

            string token = CreateToken(user);
            string refreshToken = GenerateRefreshToken();

            RefreshTokenEntity tokens = new RefreshTokenEntity
            {
                RefreshTokenValue = refreshToken,
                UserId = user.Id,
                Expiration = DateTime.Now.AddDays(7)
            };

            _authRepository.AddUserRefreshTokens(tokens);

            UsuarioEntityDto userDto = new UsuarioEntityDto()
            {
                Id = user.Id,
                NombreUsuario = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Nombres = user.Name,
                Apellidos = user.SecondName,
            };
            return new BaseResponse<UserLoginDto>
            {
                Response = new UserLoginDto { AccessToken = token, User = userDto },
                Message = "Generate Token.",
                StatusCode = StatusCodes.Status200OK,
            };
        }

        private bool VefiryPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        public BaseResponse<UserLoginDto> Refresh(Tokens tokens)
        {
            string accessToken = tokens.AccessToken;
            string refreshToken = tokens.RefreshToken;
            var principal = GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity!.Name;
            var isExistedUserName = _userRepository.GetByUserName(username!);

            if (isExistedUserName == null)
                return new BaseResponse<UserLoginDto>
                {
                    Message = "Error no se encontro usuario",
                    Response = new UserLoginDto(),
                    StatusCode = StatusCodes.Status400BadRequest
                };

            var savedRefreshToken = _authRepository.GetRefreshToken(isExistedUserName!.Id, refreshToken);

            if (savedRefreshToken is null || savedRefreshToken.RefreshTokenValue != refreshToken || savedRefreshToken.Expiration <= DateTime.Now)
            {
                return new BaseResponse<UserLoginDto>
                {
                    Message = "Unauthorized",
                    Response = new UserLoginDto(),
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            var newAccessToken = CreateToken(isExistedUserName!);
            var newRefreshToken = GenerateRefreshToken();

            RefreshTokenEntity generateTokens = new RefreshTokenEntity
            {
                RefreshTokenValue = newRefreshToken,
                UserId = isExistedUserName!.Id,
                Expiration = DateTime.Now.AddDays(7),
                Active = true,
            };

            _authRepository.DeleteUserRefreshTokens(isExistedUserName!.Id, refreshToken);
            _authRepository.AddUserRefreshTokens(generateTokens);

            return new BaseResponse<UserLoginDto>
            {
                Message = "Autenticacion Realizada",
                StatusCode = StatusCodes.Status200OK,
                Response = new UserLoginDto
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                }
            };
        }

        public BaseResponse<UsuarioEntityDto> Create(UsuarioEntityDto dto)
        {
            if (dto is null)
            {
                return new BaseResponse<UsuarioEntityDto>
                {
                    Response = null,
                    Message = "El modelo es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                };
            }

            var isExistedEmail = _userRepository.GetByEmail(dto.Email!);

            if (isExistedEmail is not null)
            {
                return new BaseResponse<UsuarioEntityDto>
                {
                    Message = "Este correo ya existe",
                    Response = new UsuarioEntityDto(),
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var isExistedUserName = _userRepository.GetByUserName(dto.NombreUsuario!);

            if (isExistedUserName is not null)
            {
                return new BaseResponse<UsuarioEntityDto>
                {
                    Message = "Este username ya existe",
                    Response = new UsuarioEntityDto(),
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var result = _userRepository.SaveUser(dto);
           // var body = @"
            //<!DOCTYPE html>
            //<html lang='en'>
            //<head>
            //    <meta charset='UTF-8'>
            //    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            //    <title>Email</title>
            //    <style>
            //        body {
            //            font-family: Arial, sans-serif;
            //            background-color: #f4f4f4;
            //            margin: 0;
            //            padding: 0;
            //        }
            //        .container {
            //            width: 100%;
            //            max-width: 600px;
            //            margin: 0 auto;
            //            background-color: #ffffff;
            //            padding: 20px;
            //            border-radius: 8px;
            //            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.15);
            //        }
            //        .header {
            //            text-align: center;
            //            padding: 20px 0;
            //            background-color: #007bff;
            //            color: white;
            //            border-radius: 8px 8px 0 0;
            //        }
            //        .header h1 {
            //            margin: 0;
            //            font-size: 24px;
            //        }
            //        .content {
            //            padding: 20px;
            //            color: #333333;
            //        }
            //        .content h2 {
            //            color: #007bff;
            //        }
            //        .content p {
            //            line-height: 1.6;
            //        }
            //        .button {
            //            display: inline-block;
            //            padding: 10px 20px;
            //            margin: 20px 0;
            //            font-size: 16px;
            //            color: white;
            //            background-color: #007bff;
            //            text-decoration: none;
            //            border-radius: 5px;
            //        }
            //        .footer {
            //            text-align: center;
            //            color: #888888;
            //            font-size: 14px;
            //            margin-top: 20px;
            //        }
            //        .footer p {
            //            margin: 5px 0;
            //        }
            //        .footer a {
            //            color: #007bff;
            //            text-decoration: none;
            //        }
            //    </style>
            //</head>
            //<body>
            //    <div class='container'>
            //        <div class='header'>
            //            <h1>Welcome to Birthflow</h1>
            //        </div>
            //        <div class='content'>
            //            <h2>Hello, [User's Name]</h2>
            //            <p>Thank you for registering with us. To complete your registration, please click the button below to activate your account:</p>
            //            <a href='[Activation Link]' class='button'>Activate Account</a>
            //            <p>If you did not register for this service, please ignore this email.</p>
            //        </div>
            //        <div class='footer'>
            //            <p>&copy; 2024 Our Company. All rights reserved.</p>
            //            <p><a href='#'>Unsubscribe</a> | <a href='#'>Privacy Policy</a></p>
            //        </div>
            //    </div>
            //</body>
            //</html>
            //";
          /*  var activateToken = new ActivationTokenEntity
            {
                Email = dto.Email!,
                Value = Guid.NewGuid().ToString(),
                Expiration = DateTime.UtcNow.AddHours(1),

            };

            _accountRepository.saveActivationToken(activateToken);

            string activationLink = $"https://localhost:7039/api/Account/activate?token?token={activateToken.Value}";


            // Replace placeholders with actual values
            body = body.Replace("[User's Name]", result.Response.NombreUsuario);
            body = body.Replace("[Activation Link]", activationLink);

            SendEmailRequest _sendEmailRequest = new(dto.Email!, "Activacion Cuenta Sesion", body);
            _mailService.SendEmailAsync(_sendEmailRequest);
          /*/
            return result;
        }

        public BaseResponse<string> ActivateAccount(string token)
        {
            var tokenEntity = _accountRepository.getActivationToken(token);

            if (tokenEntity == null || tokenEntity.Expiration < DateTime.UtcNow)
            {
                return new BaseResponse<string>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Response = "Invalid or expired token. Please request a new activation link.",
                    Message = "Invalid or expired token. Please request a new activation link."
                };
            }

            var user = _userRepository.GetByEmail(tokenEntity.Email);

            user!.IsActive = true;

            return new BaseResponse<string>
            {
                StatusCode = StatusCodes.Status200OK,
                Response = "Account activated successfully.",
                Message = "Account activated successfully."
            };
        }
    }
}