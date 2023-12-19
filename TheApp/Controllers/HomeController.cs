using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using TheApp.IO.DataCom;
using TheApp.Models;
using TheApp.Objects;

namespace TheApp.Controllers
{
    public class HomeController : Controller
    {
        int indexLoad = 1;
        private readonly IWebHostEnvironment _environment;

        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index(int? load)
        {
            var contentRootPath = _environment.ContentRootPath;
            var relativePath = Path.Combine("wwwroot", "uploads");
            var fullSavePath = Path.Combine(contentRootPath, relativePath);
            
            if(load == 0)
            {
                ViewData["FirstLoad"] = 0;
            }
            else
            {
                ViewData["FirstLoad"] = 1;
            }
             


            ViewData["path"] = Path.Combine(contentRootPath, relativePath).ToString();
            return View();
        }

        public IActionResult LoadPage(string target)
        {
            if (target.Equals("Home"))
            {
                indexLoad = 0;
                return RedirectToAction("Index", new { load = 0}); 
            }

            return RedirectToAction("Main");
        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult EditUser()
        {
            return View();
        }

        public IActionResult SideBar() 
        {
            return View();
        }


        [HttpPost]
        public IActionResult State(string stateCode)
        {
            try
            {
                //state code is usually like XX-St, US-GA so extracting last 2 places in char[] > string.
                char[] st = stateCode.ToArray();
                string str = st[st.Length - 2].ToString() + st[st.Length - 1].ToString();

                string state = TheApp.DataList.State.getState(str);

                ViewData["state"] = state;
                return PartialView("State");
            }catch (Exception ex)
            {
                string message = ex.Message;
                return PartialView(message);
            }
            
        }

        // Only Here For: issue with FileController upload method not being called from file partial
        // , which is called from a view on the HomeController??? 
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    var uploadsDirectory = Path.Combine(_environment.WebRootPath, "uploads");

                    if (!Directory.Exists(uploadsDirectory))
                    {
                        Directory.CreateDirectory(uploadsDirectory);
                    }

                    var contentRootPath = _environment.ContentRootPath;
                    var relativePath = "uploads"; // Relative to the web root
                    var fullSavePath = Path.Combine(contentRootPath, "wwwroot", relativePath);
                    var filePath = Path.Combine(fullSavePath, file.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }



                    // You can process the uploaded file here or save the file path to a database

                    return RedirectToAction("Index"); // Redirect to the home page after a successful upload
                }

                return View("Index"); // Return to the upload form if no file is uploaded

            }
            catch (Exception ex)
            {
                ViewData["path"] = ex.ToString();
                return View("Index"); // Return to the upload form if no file is uploaded
            }

        }

        public IActionResult Testing()
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