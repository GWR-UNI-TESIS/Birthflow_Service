using Microsoft.AspNetCore.Mvc;

namespace BirthflowService.API.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
