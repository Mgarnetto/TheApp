namespace TheApp.Objects
{
    public class File
    {
        public int fileID { get; set; }
        public int userID { get; set; } // user who uploaded file
        public string fileName { get; set; } //varchar 100 
        public string fileTitle { get; set; } //varchar 100 more formal for display
        public string fileServer { get; set; } //varchar 20 server where file is hosted
        public string filePath { get; set; } //varchar 50 location on the server
        public string fileType { get; set; } //varchar 20 audio/video/image also profile / image-profile-default
        public DateTime modifiedDateTime { get; set; } // when it was created/modified

        public File()
        {
            // Default constructor
        }

        public File(int userID, string fileName, string fileTitle, string fileServer, string filePath, string fileType, DateTime modifiedDateTime)
        {
            this.userID = userID;
            this.fileName = fileName;
            this.fileTitle = fileTitle;
            this.fileServer = fileServer;
            this.filePath = filePath;
            this.fileType = fileType;
            this.modifiedDateTime = modifiedDateTime;   
        }
    }

}
