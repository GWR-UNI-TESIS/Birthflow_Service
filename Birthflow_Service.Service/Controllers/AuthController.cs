using Azure.Core;
using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Application.Services;
using Birthflow_Domain.Interface;
using Birthflow_Service.Application.Models;
using BirthflowService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Birthflow_Application.DTOs.Auth.UsuarioEntityDto;

namespace Birthflow_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authServices;
        public AuthController(IAuthService authService)
        {
            _authServices = authService;
        }

        [HttpPost("create/user")]
        public IActionResult Create([FromBody] UsuarioEntityDto user)
        {
            return Ok(_authServices.Create(user));
        }
        [HttpGet("activate")]
        public IActionResult ActivateAccount(string token)
        {
            return Ok(_authServices.ActivateAccount(token));
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            return Ok(_authServices.Login(request));
           /* UserEntity? user;

            user = _authServices.GetByUserName(request.Email);
            if (user is null)
                user = _authServices.GetByEmail(request.Email);

            if (user is null)
                return NotFound(new BaseResponse<UserLoginDto>
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


            UsuarioEntityDto userDto = new UsuarioEntityDto()
            {
                Id = user.Id,
                NombreUsuario = user.NombreUsuario,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,

            };
            return Ok(new BaseResponse<UserLoginDto>
            {
                Response = new UserLoginDto { Token = token, User = userDto },
                Message = "Generate Token.",
                StatusCode = StatusCodes.Status200OK,
            });*/
        }

        /*
        [HttpGet("Get/User/{userId}")]
        [Authorize]
        public IActionResult GetUser([FromRoute] Guid userId)
        {
            if (userId == Guid.Empty)
                return Ok(new BaseResponse<UserEntity>
                {
                    Response = default,
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });

            var getUser = _authServices.GetById(userId);

            if (getUser is null)
                return Ok(new BaseResponse<UserEntity>
                {
                    Response = default,
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });

            getUser.PasswordHash = string.Empty;
            return Ok(new BaseResponse<UserEntity>
            {
                Response = getUser,
                Message = "User found",
                StatusCode = StatusCodes.Status200OK,
            });
        }/*/
        /*
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

            var getUser = _authServices.GetById((Guid)user.Id);

            if (getUser is null)
                return Ok(new BaseResponse<UserEntity>
                {
                    Response = default,
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });

            var response = _authServices.UpdateUser(user, getUser);

            return Ok(new BaseResponse<UserEntity>
            {
                Response = new UserEntity(),
                Message = "User was update success",
                StatusCode = StatusCodes.Status200OK
            });
        }*/
    }
}
