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
        private readonly IWebHostEnvironment _environment;

        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contentRootPath = _environment.ContentRootPath;
            var relativePath = Path.Combine("wwwroot", "uploads");
            var fullSavePath = Path.Combine(contentRootPath, relativePath);

            ViewData["path"] = Path.Combine(contentRootPath, relativePath).ToString();
            return View();
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


        public IActionResult spIndex()
        {
            return View();
        }

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