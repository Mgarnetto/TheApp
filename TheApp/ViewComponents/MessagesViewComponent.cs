using Microsoft.AspNetCore.Mvc;

namespace TheApp.ViewComponents
{
    public class MessagesViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
