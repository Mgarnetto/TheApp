using Microsoft.AspNetCore.Mvc;

namespace TheApp.ViewComponents
{
    public class ReceiverOfMessageViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
