using Microsoft.AspNetCore.Mvc;

namespace TheApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            
                //< img src = "@Url.Content("~/ uploads / " + pic[0].fileName)" alt = "Profile Picture 1" > 
            return View();
        }
    }
}
