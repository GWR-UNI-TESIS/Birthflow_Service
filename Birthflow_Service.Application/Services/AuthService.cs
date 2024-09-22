using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Domain.Interface;
using Birthflow_Service.Application.Models;
using BirthflowService.Application.Interfaces;
using BirthflowService.Application.Models;
using BirthflowService.Domain.DTOs.Contracts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using BirthflowService.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly IPasswordRepository _passwordRepository;
        private readonly ITokenService _tokenService;
        private readonly IMailAdapter _mailService;

        public AuthService(IConfiguration configuration, ILogger<AuthService> logger, IUserRepository userRepository, IAuthRepository authRepository, 
            IMailAdapter mailService, IAccountRepository accountRepository, IPasswordRepository passwordRepository, ITokenService tokenService)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _authRepository = authRepository;
            _mailService = mailService;
            _logger = logger;
            _accountRepository = accountRepository;
            _passwordRepository = passwordRepository;
            _tokenService = tokenService;
        }

     
        public async Task<BaseResponse<UserLoginDto>> Login(LoginModel request)
        {
            UserEntity? user;

            user = await _userRepository.GetByUserName(request.Email);
            if (user is null)
                user = await _userRepository.GetByEmail(request.Email);

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
            var currentPassword = await _passwordRepository.GetPassword(user.Id);


            if (!BCrypt.Net.BCrypt.Verify(request.Password, currentPassword!.PasswordHash!))
            {
                return new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "Invalid Credential.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }

            string token = _tokenService.CreateToken(user);
            string refreshToken = _tokenService.GenerateRefreshToken();

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
        public async Task<BaseResponse<UserLoginDto>> Refresh(Tokens tokens)
        {
            string accessToken = tokens.AccessToken;
            string refreshToken = tokens.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity!.Name;
            var isExistedUserName = await _userRepository.GetByUserName(username!);

            if (isExistedUserName == null)
                return new BaseResponse<UserLoginDto>
                {
                    Message = "Error no se encontro usuario",
                    Response = new UserLoginDto(),
                    StatusCode = StatusCodes.Status400BadRequest
                };

            var savedRefreshToken =  _authRepository.GetRefreshToken(isExistedUserName!.Id, refreshToken);

            if (savedRefreshToken is null || savedRefreshToken.RefreshTokenValue != refreshToken || savedRefreshToken.Expiration <= DateTime.Now)
            {
                return new BaseResponse<UserLoginDto>
                {
                    Message = "Unauthorized",
                    Response = new UserLoginDto(),
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            var newAccessToken = _tokenService.CreateToken(isExistedUserName!);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

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
        public async Task<BaseResponse<UsuarioEntityDto>> Create(UsuarioEntityDto dto)
        {
            if (dto is null)
            {
                return new BaseResponse<UsuarioEntityDto>
                {
                    Response = new UsuarioEntityDto(),
                    Message = "El modelo es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                };
            }

            var isExistedEmail = await _userRepository.GetByEmail(dto.Email!);

            if (isExistedEmail is not null)
            {
                return new BaseResponse<UsuarioEntityDto>
                {
                    Message = "Este correo ya existe",
                    Response = new UsuarioEntityDto(),
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var isExistedUserName = await _userRepository.GetByUserName(dto.NombreUsuario!);

            if (isExistedUserName is not null)
            {
                return new BaseResponse<UsuarioEntityDto>
                {
                    Message = "Este username ya existe",
                    Response = new UsuarioEntityDto(),
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var result = await _userRepository.SaveUser(dto);

            UsuarioEntityDto userDto = new UsuarioEntityDto()
            {
                Id = result.Id,
                NombreUsuario = result.UserName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                Nombres = result.Name,
                Apellidos = result.SecondName,
            };

            return new BaseResponse<UsuarioEntityDto>
            {
                Response = userDto,
                Message = "Generate Token.",
                StatusCode = StatusCodes.Status200OK,
            };

        }
        public async Task<BaseResponse<string>> ActivateAccount(string token)
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

            var user = await _userRepository.GetByEmail(tokenEntity.Email);

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