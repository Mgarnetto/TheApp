using Microsoft.AspNetCore.Mvc;
using TheApp.IO.DataCom;
using TheApp.Objects;

namespace TheApp.ViewComponents
{
    public class PostViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(string type, int ID) // type = User/State etc and ID = postingID etc
        {
            if (type == null)
            {
                Post[] p = new GetPosts().GetAll();
                return View(p);
            }else if(type.Equals("User")){
                Post[] p = new GetPosts().GetPostsByCategoryAndID("User", ID);
                return View(p);
            }  
            else
            {
                return View(null);
            }
            
        }

        
    }
}
