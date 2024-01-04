using Microsoft.AspNetCore.Mvc;

namespace TheApp.ViewComponents
{
    public class TopArtistsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
