using Microsoft.AspNetCore.Mvc;
using TheApp.IO.DataCom;
using TheApp.Objects;

namespace TheApp.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {


        public IViewComponentResult Invoke(int[] ID)
        {
            if(ID.Length == 2)
            {
                int mediaId = ID[0]; 
                int parentId = ID[1]; 

                Comment[] c = new GetComments().GetCommentByMediaID(mediaId, parentId);
                return View(c);
            }
            else if(ID.Length == 1) 
            {
                int mediaId = ID[0];
                Comment[] c = new GetComments().GetCommentByMediaID(mediaId);
                return View(c);
            }
            else
            {
                return View(null);
            }


        }

        //public IViewComponentResult Invoke(int mediaElementID)
        //{
        //    Comment[] c = new GetComments().GetCommentByMediaID(mediaElementID);
        //    return View(c);
        //}
        //public IViewComponentResult Invoke(int mediaElementID, int parentComentID)
        //{
        //    Comment[] c = new GetComments().GetCommentByMediaID(mediaElementID, parentComentID);
        //    return View(c);
        //}
    }
}
