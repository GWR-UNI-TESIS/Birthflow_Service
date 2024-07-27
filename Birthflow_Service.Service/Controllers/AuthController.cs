using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Application.Services;
using Birthflow_Domain.Interface;
using BirthflowMicroServices.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace Birthflow_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authService)
        {
            _authServices = authService;
        }
        [HttpGet("Login/User")]
        [Authorize]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("Create/user")]
        public IActionResult CreateUser([FromBody] UsuarioEntityDto user)
        {
            if (user is null)
            {
                return BadRequest(new BaseResponse<UsuarioEntityDto>
                {
                    Response = null,
                    Message = "El modelo es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }

            var response = _authServices.SaveUser(user);

            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserDto request)
        {
            UsuarioEntity? user;

            user = _authServices.GetByUserName(request.Email);
            if (user is null)
                user = _authServices.GetByEmail(request.Email);

            if (user is null)
                return Ok(new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "User not found.",
                    StatusCode = StatusCodes.Status404NotFound,
                });

            if (user.IsDelete)
                return Ok(new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });

            if (user.NombreUsuario != request.Email && user.Email != request.Email)
            {
                return Ok(new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "User not found.",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }
            if (!_authServices.VefiryPassword(request.Password, user.PasswordHash))
            {
                return Ok(new BaseResponse<UserLoginDto>
                {
                    Response = new UserLoginDto(),
                    Message = "Invalid Credential.",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }

            string token = _authServices.CreateToken(user);

            return Ok(new BaseResponse<UserLoginDto>
            {
                Response = new UserLoginDto { Token = token, User = user },
                Message = "Generate Token.",
                StatusCode = StatusCodes.Status200OK,
            });
        }

        [HttpGet("Get/User/{userId}")]
        [Authorize]
        public IActionResult GetUser([FromRoute] Guid userId)
        {
            if (userId == Guid.Empty)
                return Ok(new BaseResponse<UsuarioEntity>
                {
                    Response = default,
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });

            var getUser = _authServices.GetById(userId);

            if (getUser is null)
                return Ok(new BaseResponse<UsuarioEntity>
                {
                    Response = default,
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });

            getUser.PasswordHash = string.Empty;
            return Ok(new BaseResponse<UsuarioEntity>
            {
                Response = getUser,
                Message = "User found",
                StatusCode = StatusCodes.Status200OK,
            });
        }

        [HttpPut("update/user")]
        public IActionResult UpdateUser([FromBody] UsuarioEntityDto user)
        {
            if (user is null)
                return Ok(new BaseResponse<UsuarioEntityDto>
                {
                    Response = default,
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });

            if (user.Id is null)
                return Ok(new BaseResponse<UsuarioEntityDto>
                {
                    Response = default,
                    Message = "UserID not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            

            var getUser = _authServices.GetById((Guid)user.Id);

            if (getUser is null)
                return Ok(new BaseResponse<UsuarioEntity>
                {
                    Response = default,
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });

            var response = _authServices.UpdateUser(user, getUser);

            return Ok(new BaseResponse<UsuarioEntity>
            {
                Response = new UsuarioEntity(),
                Message = "User was update success",
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
