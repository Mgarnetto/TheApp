using Microsoft.AspNetCore.Mvc;

namespace TheApp.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetThread(string senderID)
        {
            int userID = int.Parse(HttpContext.Session.GetString("UserID"));

            ViewData["userID"] = userID;
            ViewData["senderID"] = senderID;
            return View();
        }
    }
}
