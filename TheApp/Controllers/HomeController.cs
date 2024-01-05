using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheApp.Models;
using TheApp.Objects;
using Microsoft.AspNetCore.Http;
using System;


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

        #region User Session

        private void CheckUser()
        {
            // Check if user information is already in session
            if (HttpContext.Session.TryGetValue("UserId", out var userIdBytes) && userIdBytes is byte[] userIdBytesArray)
            {
                string userId = System.Text.Encoding.UTF8.GetString(userIdBytesArray);

                // User information is in the session, you can use it
                HttpContext.Session.SetString("UserId", userId);

                ViewData["UserId"] = userId;
            }
            else
            {
                // User information is not in the session, set it
                //string newUserId = "123"; // Replace with your logic to get or generate the user ID
                //HttpContext.Session.SetString("UserId", newUserId);
                //ViewData["UserId"] = newUserId;
            }
        }

        private bool IsUserInSession()
        {
            return HttpContext.Session.TryGetValue("UserId", out _);
        }

        #endregion

        #region nav 
        [HttpGet]
        public IActionResult Index(int? load)
        {
            //session stuffs
            //if (!IsUserInSession())
            //{
            //    // User information is not in the session, redirect to SelectUser action
            //    return RedirectToAction(nameof(SelectUser));
            //}

            var contentRootPath = _environment.ContentRootPath;
            var relativePath = Path.Combine("wwwroot", "uploads");
            var fullSavePath = Path.Combine(contentRootPath, relativePath);

            if (load == 0)
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
            //if (!IsUserInSession())
            //{
            //    // User information is not in the session, redirect to SelectUser action
            //    return RedirectToAction(nameof(SelectUser));
            //}

            if (target.Equals("Home"))
            {
                indexLoad = 0;
                return RedirectToAction("Index", new { load = 0 });
            }
            else if (target.Equals("Testing"))
            {
                return RedirectToAction("Testing");
            }
            else if (target.Equals("SelectUser"))
            {
                return RedirectToAction("SelectUser");
            }
            else if (target.Equals("SeedFiles"))
            {
                return RedirectToAction("SeedFiles");
            }else if (target.Equals("UserPage"))
            {
                return RedirectToAction("UserPage");
            }else if (target.Equals("Text"))
            {
                return RedirectToAction("Text");
            }

            return RedirectToAction("Main");
        }

        public IActionResult Text()
        {
            return View();
        }

        public IActionResult SelectUser()
        {
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult UserPage(int id)
        {
            //HttpContext.Session.SetString("UserId", id.ToString());

            ViewData["userID"] = id;
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
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return PartialView(message);
            }

        }

        public IActionResult SeedFiles()
        {
            return View();
        }

        #endregion

        #region upload
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
        #endregion

        #region testupload
        public async Task<IActionResult> TestUpload(IFormFile file)
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

                    //pulling user to create OUR file object > save OUR file object
                    TheApp.Objects.User[] user = new TheApp.IO.DataCom.GetUsers().GetUser(1);
                    TheApp.Objects.File f = new Objects.File();
                    f.userID = user[0].userID;
                    f.mediaElementID = user[0].userID;
                    f.fileServer = "main";
                    f.fileName = file.FileName;
                    f.fileTitle = "Test file";
                    f.filePath = fullSavePath;
                    f.fileType = FileTypes.profile;
                    f.modifiedDateTime = DateTime.Now;

                    f.fileID = new TheApp.IO.DataCom.CreateFile().InsertFile(f);

                    // You can process the uploaded file here or save the file path to a database
                    ViewData["FirstLoad"] = 0;
                    return RedirectToAction("Index"); // Redirect to the home page after a successful upload
                }

                ViewData["FirstLoad"] = 0;
                return View("Index"); // Return to the upload form if no file is uploaded

            }
            catch (Exception ex)
            {
                ViewData["FirstLoad"] = 0;
                return View("Index"); // Return to the upload form if no file is uploaded
            }

        }
        #endregion

        #region test
        public IActionResult Testing()
        {
            return View();
        }
        #endregion

        #region error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}