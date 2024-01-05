using Microsoft.AspNetCore.Mvc;

namespace TheApp.ViewComponents
{
    public class FilePostViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
