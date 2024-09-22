using BirthflowService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthflowService.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("activate")]
        public IActionResult Activate(string token)
        {
            var result = _authService.ActivateAccount(token);

            /*if (result.StatusCode == StatusCodes.Status200OK)
            {
                ViewBag.Message = "Account activated successfully. This window will close shortly.";
                ViewBag.Success = true;
            }
            else
            {
                ViewBag.Message = result.Message;
                ViewBag.Success = false;
            }*/

            return View(); // Esto retorna la vista asociada a la activación
        }
    }
}
