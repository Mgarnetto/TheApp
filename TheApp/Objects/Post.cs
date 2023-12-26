namespace TheApp.Objects
{
    public class Post
    {   // category isn't right, starts with C instead of c as well as PostingID
        public int postID { get; set; }
        public int userID { get; set; }
        public string postType { get; set; }
        public string postText { get; set; }
        public string mediaFilePath { get; set; }
        public int mediaElementID { get; set; } // to be set by db. so hit db then pages
        public DateTime timeStamp { get; set; }
        public string Category { get; set; } // user, classifieds, etc.
        public int PostingID { get; set; } //where it was posted.

        public Post()
        {

        }

        public Post(int postID, int userID, string postType, string postText, string mediaFilePath, 
            int mediaElementID, DateTime timeStamp, string Category, int PostingID)
        {
            this.postID = postID;
            this.userID = userID;
            this.postType = postType;
            this.postText = postText;
            this.mediaFilePath = mediaFilePath;
            this.mediaElementID = mediaElementID;
            this.timeStamp = timeStamp;
            this.Category = Category;
            this.PostingID = PostingID;
        }
    }
}
