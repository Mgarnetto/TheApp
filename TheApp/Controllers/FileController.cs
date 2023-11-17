using Microsoft.AspNetCore.Mvc;

namespace TheApp.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
