using AutoMapper;
using Azure.Core;
using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Domain.Interface;
using Birthflow_Service.Application.Models;
using BirthflowService.Application.Interfaces;
using BirthflowService.Application.Models;
using BirthflowService.Domain.DTOs.Auth;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using BirthflowService.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Birthflow_Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordRepository _passwordRepository;
        private readonly ITokenService _tokenService;
        private readonly IMailAdapter _mailService;
        private readonly IUserTokenService _userTokenService;


        public AuthService(IConfiguration configuration, ILogger<AuthService> logger, IUserRepository userRepository, IAuthRepository authRepository, 
            IMailAdapter mailService, IAccountRepository accountRepository, IPasswordRepository passwordRepository, ITokenService tokenService, IMapper mapper, IUserTokenService userTokenService)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _authRepository = authRepository;
            _mailService = mailService;
            _logger = logger;
            _accountRepository = accountRepository;
            _passwordRepository = passwordRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _userTokenService = userTokenService;
        }
     
        public async Task<BaseResponse<UserLoginDto>> Login(LoginModel request)
        {
            UserEntity? user;

            var ipAddress = _userTokenService.GetIpAddress();


            user = await _userRepository.GetByUserName(request.Email);
            if (user is null)
                user = await _userRepository.GetByEmail(request.Email);

            if (user is null)
            {
                await _authRepository.AddLoginAttempt(new UserLoginAttemptEntity
                {
                    UserId = null, // Usuario no encontrado
                    AttemptTimestamp = DateTime.Now,
                    IPAddress = ipAddress, // Asegúrate de que la IP se pase en la solicitud
                    Success = false,
                    FailureReason = "User not found."
                });

                return new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "User not found.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }

            if (user.IsDelete)
            {
                await _authRepository.AddLoginAttempt(new UserLoginAttemptEntity
                {
                    UserId = user.Id, // Usuario no encontrado
                    AttemptTimestamp = DateTime.Now,
                    IPAddress = ipAddress, // Asegúrate de que la IP se pase en la solicitud
                    Success = false,
                    FailureReason = "User not valid."
                });

                return new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }

            if (user.UserName != request.Email && user.Email != request.Email)
            {
                await _authRepository.AddLoginAttempt(new UserLoginAttemptEntity
                {
                    UserId = user.Id, // Usuario no encontrado
                    AttemptTimestamp = DateTime.Now,
                    IPAddress = ipAddress, // Asegúrate de que la IP se pase en la solicitud
                    Success = false,
                    FailureReason = "User not found."
                });

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
                await _authRepository.AddLoginAttempt(new UserLoginAttemptEntity
                {
                    UserId = user.Id, // Usuario no encontrado
                    AttemptTimestamp = DateTime.UtcNow,
                    IPAddress = ipAddress, // Asegúrate de que la IP se pase en la solicitud
                    Success = false,
                    FailureReason = "nvalid Credential."
                });

                return new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "Invalid Credential.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }

            await _authRepository.AddLoginAttempt(new UserLoginAttemptEntity
            {
                UserId = user.Id,
                AttemptTimestamp = DateTime.Now,
                IPAddress = ipAddress,
                Success = true,
            });

            string token = _tokenService.CreateToken(user);
            string refreshToken = _tokenService.GenerateRefreshToken();

            RefreshTokenEntity tokens = new RefreshTokenEntity
            {
                RefreshTokenValue = refreshToken,
                UserId = user.Id,
                Expiration = DateTime.Now.AddDays(7)
            };

            _authRepository.AddUserRefreshTokens(tokens);

            var userDto =_mapper.Map<UserDto>(user);

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
        public async Task<BaseResponse<UserDto>> Create(UserDto dto)
        {
            if (dto is null)
            {
                return new BaseResponse<UserDto>
                {
                    Response = new UserDto(),
                    Message = "El modelo es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                };
            }

            var isExistedEmail = await _userRepository.GetByEmail(dto.Email!);

            if (isExistedEmail is not null)
            {
                return new BaseResponse<UserDto>
                {
                    Message = "Este correo ya existe",
                    Response = new UserDto(),
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var isExistedUserName = await _userRepository.GetByUserName(dto.UserName!);

            if (isExistedUserName is not null)
            {
                return new BaseResponse<UserDto>
                {
                    Message = "Este username ya existe",
                    Response = new UserDto(),
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var result = await _userRepository.SaveUser(dto);

            var password = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);

            var passwordEntity = new PasswordEntity
            {
                UserId = result.Id,
                PasswordHash = password,
                IsCurrent = true,
                CreateAt = DateTime.UtcNow,
            };

            await _passwordRepository.CreatePassword(passwordEntity);

            var userDto = _mapper.Map<UserDto>(result);

            return new BaseResponse<UserDto>
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