using Microsoft.AspNetCore.Mvc;

namespace TheApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
