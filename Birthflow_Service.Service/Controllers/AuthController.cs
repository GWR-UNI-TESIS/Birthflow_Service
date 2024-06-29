using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
using Birthflow_Application.Services;
using Birthflow_Domain.Interface;
using Microsoft.AspNetCore.Mvc;

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
                    Response = user,
                    Message = "User not valid.",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }

            var response = _authServices.SaveUser(user);

            return Ok(response);
        }
    }
}
