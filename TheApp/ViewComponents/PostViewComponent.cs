using Microsoft.AspNetCore.Mvc;
using TheApp.IO.DataCom;
using TheApp.Objects;

namespace TheApp.ViewComponents
{
    public class PostViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            Post[] p = new GetPosts().GetAll();
            return View(p);
        }

        
    }
}
