using Azure.Core;
using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Application.Utils;
using Birthflow_Domain.Interface;
using Birthflow_Infraestructure.Repositories;
using Birthflow_Service.Application.Models;
using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowMicroServices.Domain.Models;
using BirthflowService.Application.Interfaces;
using BirthflowService.Application.Models;
using BirthflowService.Application.Utils.Contracts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace Birthflow_Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;

        public AuthService(IConfiguration configuration, IUserRepository userRepository, IAuthRepository authRepository, IMailService mailService)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _authRepository = authRepository;
            _mailService = mailService;
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

            if(isExistedUserName == null)
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
                RefreshTokenValue = refreshToken,
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
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
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

            SendEmailRequest _sendEmailRequest = new (dto.Email, "Inicio Sesion", " Puebraaaaaaa");
            _mailService.SendEmailAsync(_sendEmailRequest);

            return result;
        }
    }
}
