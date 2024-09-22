using Birthflow_Application.DTOs.Auth;
using Birthflow_Service.Application.Models;
using BirthflowService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Birthflow_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authServices;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authServices = authService;
            _logger = logger;
        }

        [HttpPost("create/user")]
        public async Task<IActionResult> Create([FromBody] UserDto user)
        {
            try
            {
                _logger.LogInformation("Intentando crear un nuevo usuario.");
                var result = await _authServices.Create(user);
                _logger.LogInformation("Usuario creado exitosamente con código de estado: {StatusCode}", result.StatusCode);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al crear el usuario.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpGet("activate")]
        public async Task<IActionResult> ActivateAccount(string token)
        {
            try
            {
                _logger.LogInformation("Intentando activar la cuenta.");
                var result = await _authServices.ActivateAccount(token);
                _logger.LogInformation("Usuario ha activado exitosamente con código de estado: {StatusCode}", result.StatusCode);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al activar la cuenta.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel request)
        {
            try
            {
                _logger.LogInformation("Intentando ingresar sesion.");
                var result = await _authServices.Login(request);
                _logger.LogInformation("Usuario ha ingresado sesion exitosamente con código de estado: {StatusCode}", result.StatusCode);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al iniciar sesion a la cuenta.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }
    }
}
