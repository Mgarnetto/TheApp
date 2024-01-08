namespace TheApp.Objects
{
    public class Comment
    {
        //@await Component.InvokeAsync("Comment", new int[]{ p.mediaElementID, p.commentID }) 
        public int commentID {  get; set; } 
        public int userID { get; set; }  
        public int mediaElementID { get; set; }
        public int parentCommentID { get; set; }
        public string commentText { get; set; }
        public DateTime timeStamp { get; set; }

        public Comment()
        {

        }

        public Comment(int commentID, int userID, int mediaElementID, int? parentCommentID,
            string commentText, DateTime timeStamp)
        {
            this.commentID = commentID;
            this.userID = userID;
            this.mediaElementID = mediaElementID;
            this.parentCommentID = parentCommentID == null ? 0 : parentCommentID.Value;
            this.commentText = commentText;
            this.timeStamp = timeStamp;
        }
        
        

    }
}
