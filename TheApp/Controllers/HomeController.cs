using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheApp.IO.DataCom;
using TheApp.Models;
using TheApp.Objects;

namespace TheApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //GetComments g = new GetComments();
            //g.GetAll();
            //Comment[] h = g.GetCommentByMediaID(1);

            return View();
        }
               

        //Unused
        //public IActionResult OnGetPartial() =>
        //    new PartialViewResult
        //    {
        //        ViewName = "_CommentPartial"
        //    };


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}