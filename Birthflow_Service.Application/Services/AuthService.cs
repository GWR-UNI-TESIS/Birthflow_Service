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
            var deviceInfo = _userTokenService.GetDevice();

            if (string.IsNullOrEmpty(deviceInfo))
            {
                return new BaseResponse<UserLoginDto>
                {
                    Response = { },
                    Message = "Device ID is required.",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }


            user = await _userRepository.GetByUserName(request.Email);
            if (user is null)
                user = await _userRepository.GetByEmail(request.Email);

            if (user is null)
            {
                await _authRepository.AddLoginAttempt(new UserLoginAttemptEntity
                {
                    UserId = null, // Usuario no encontrado
                    AttemptTimestamp = DateTime.UtcNow,
                    IPAddress = ipAddress, // Asegúrate de que la IP se pase en la solicitud
                    Success = false,
                    FailureReason = "User not found."
                });

                return new BaseResponse<UserLoginDto>
                {
                    Response = { },
                    Message = "User not found.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }

            if (user.IsDelete)
            {
                await _authRepository.AddLoginAttempt(new UserLoginAttemptEntity
                {
                    UserId = user.Id, // Usuario no encontrado
                    AttemptTimestamp = DateTime.UtcNow,
                    IPAddress = ipAddress, // Asegúrate de que la IP se pase en la solicitud
                    Success = false,
                    FailureReason = "User not valid."
                });

                return new BaseResponse<UserLoginDto>
                {
                    Response = {},
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }

            if (user.UserName != request.Email && user.Email != request.Email)
            {
                await _authRepository.AddLoginAttempt(new UserLoginAttemptEntity
                {
                    UserId = user.Id, // Usuario no encontrado
                    AttemptTimestamp = DateTime.UtcNow,
                    IPAddress = ipAddress, // Asegúrate de que la IP se pase en la solicitud
                    Success = false,
                    FailureReason = "User not found."
                });

                return new BaseResponse<UserLoginDto>
                {
                    Response = { },
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
                    Response = { },
                    Message = "Invalid Credential.",
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }

            await _authRepository.AddLoginAttempt(new UserLoginAttemptEntity
            {
                UserId = user.Id,
                AttemptTimestamp = DateTime.UtcNow,
                IPAddress = ipAddress,
                Success = true,
            });

            // Verificar si ya existe un refresh token para este dispositivo
            var existingToken = await _authRepository.GetRefreshTokenByUserIdAndDeviceId(user.Id, deviceInfo);
            if (existingToken != null)
            {
                // Invalida el token existente si ya existe uno activo para el dispositivo
                existingToken.Active = false;
                await _authRepository.UpdateUserRefreshTokens(existingToken);
            }

            string token = _tokenService.CreateToken(user);
            string refreshToken = _tokenService.GenerateRefreshToken();

            RefreshTokenEntity tokens = new RefreshTokenEntity
            {
                RefreshTokenValue = refreshToken,
                UserId = user.Id,
                Device = deviceInfo,
                Active = true,
                Expiration = DateTime.UtcNow.AddDays(7)
            };

            _authRepository.AddUserRefreshTokens(tokens);

            var session = await _authRepository.GetActiveSessionByUserIdAndDeviceId(user.Id, deviceInfo);
            if (session == null)
            {
                session = new UserSessionHistoryEntity
                {
                    UserId = user.Id,
                    SessionStartTime = DateTime.UtcNow,
                    LastActivity = DateTime.UtcNow, // Nueva actividad registrada
                    IPAddress = ipAddress,  // Asegúrate de pasar la IP en la solicitud
                    Device = deviceInfo,
                    SessionToken = refreshToken,
                    IsActive = true
                };
                await _authRepository.AddUserSession(session);
            }
            else
            {
                session.LastActivity = DateTime.UtcNow;  // Actualizar la última actividad
                await _authRepository.UpdateUserSession(session);
            }

            var userDto =_mapper.Map<UserDto>(user);

            return new BaseResponse<UserLoginDto>
            {
                Response = new UserLoginDto { RefreshToken = refreshToken, AccessToken = token, User = userDto },
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
            var deviceInfo = _userTokenService.GetDevice();

            if (string.IsNullOrEmpty(deviceInfo))
            {
                return new BaseResponse<UserLoginDto>
                {
                    Response = { },
                    Message = "Device ID is required.",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }


            if (isExistedUserName == null)
                return new BaseResponse<UserLoginDto>
                {
                    Message = "Error no se encontro usuario",
                    Response = { },
                    StatusCode = StatusCodes.Status400BadRequest
                };

            var savedRefreshToken =  await _authRepository.GetRefreshToken(isExistedUserName!.Id, refreshToken);

            if (savedRefreshToken is null || savedRefreshToken.RefreshTokenValue != refreshToken)
            {
                return new BaseResponse<UserLoginDto>
                {
                    Message = "Unauthorized",
                    Response = { },
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            if ( savedRefreshToken.Expiration <= DateTime.UtcNow)
            {
                var currentSession = await _authRepository.GetActiveSessionByUserIdAndDeviceId(isExistedUserName!.Id, refreshToken);

                if (currentSession != null && currentSession.IsActive)
                {
                    currentSession.IsActive = false; // Marcar la sesión como inactiva
                    currentSession.SessionEndTime = DateTime.UtcNow; // Registrar la hora de finalización de la sesión
                    await _authRepository.UpdateUserSession(currentSession);
                }
                return new BaseResponse<UserLoginDto>
                {
                    Message = "Unauthorized",
                    Response = { },
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            var newAccessToken = _tokenService.CreateToken(isExistedUserName!);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            RefreshTokenEntity generateTokens = new RefreshTokenEntity
            {
                RefreshTokenValue = newRefreshToken,
                UserId = isExistedUserName!.Id,
                Device = deviceInfo,
                Expiration = DateTime.UtcNow.AddDays(7),
                Active = true,
            };

            _authRepository.DeleteUserRefreshTokens(isExistedUserName!.Id, refreshToken);
            _authRepository.AddUserRefreshTokens(generateTokens);

            // Actualizar la actividad de la sesión
            var session = await _authRepository.GetActiveSessionByUserIdAndDeviceId(isExistedUserName.Id, deviceInfo);
            if (session != null && session.IsActive)
            {
                session.LastActivity = DateTime.UtcNow;  // Actualizar la última actividad
                session.SessionToken = newRefreshToken;   // Actualizar el token de sesión si es necesario
                await _authRepository.UpdateUserSession(session);
            }

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

        public async Task<BaseResponse<string>> Logout(Tokens tokens)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(tokens.AccessToken);
            var userId = principal.FindFirst("UserId").Value;

            // Obtener el refresh token desde la base de datos
            var tokenEntity = await _authRepository.GetRefreshToken(Guid.Parse(userId), tokens.RefreshToken);

            if (tokenEntity == null || !tokenEntity.Active)
            {
                return new BaseResponse<string>
                {
                    Response = "Token not found or already inactive.",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Invalidar el refresh token
            tokenEntity.Active = false;
            tokenEntity.Expiration = DateTime.UtcNow; // Opcional: si quieres establecer la fecha de expiración a la fecha actual
            await _authRepository.UpdateUserRefreshTokens(tokenEntity);

            // Buscar la sesión activa asociada al usuario y refresh token
            var session = await _authRepository.GetSessionByRefreshToken(tokens.RefreshToken);
            if (session != null && session.IsActive)
            {
                // Marcar la sesión como cerrada
                session.IsActive = false;
                session.SessionEndTime = DateTime.UtcNow; // Establecer la hora de finalización de la sesión
                await _authRepository.UpdateUserSession(session);
            }

            return new BaseResponse<string>
            {
                Response = "Logout successful.",
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}