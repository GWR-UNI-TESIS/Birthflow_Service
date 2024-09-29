using Microsoft.AspNetCore.Mvc;

namespace BirthflowService.API.Controllers
{
    public class ShareController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
