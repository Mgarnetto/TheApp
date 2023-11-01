using Microsoft.AspNetCore.Mvc;

namespace TheApp.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
