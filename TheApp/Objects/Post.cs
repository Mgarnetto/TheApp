namespace TheApp.Objects
{
    public class Post
    {   // category isn't right, starts with C instead of c as well as PostingID
        public int postID { get; set; }
        public int userID { get; set; } // user who posted it
        public string postType { get; set; } // text image video audio
        public string postText { get; set; } // what text is on the post
        public string mediaFilePath { get; set; } // path to media of post type
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
