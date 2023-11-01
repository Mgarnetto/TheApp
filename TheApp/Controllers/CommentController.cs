using Microsoft.AspNetCore.Mvc;

namespace TheApp.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
