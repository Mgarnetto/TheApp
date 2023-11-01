namespace TheApp.IO.DataCom
{
    public class CreatePost
    {
        /** 
         * -- First, find the next available mediaElementID
            DECLARE @NextMediaElementID INT;
            SELECT @NextMediaElementID = ISNULL(MAX(mediaElementID), 0) + 1 FROM Post;

            -- Insert a new post with the next available mediaElementID
            INSERT INTO Post (userID, postType, postText, mediaFilePath, mediaElementID, timeStamp, Category, PostingID)
            VALUES
            (1, 'Text', 'This is a new text post.', 'new_text.txt', @NextMediaElementID, GETDATE(), 'User', 4),
            (2, 'Image', 'Image post description', 'image1.jpg', @NextMediaElementID + 1, GETDATE(), 'User', 5),
            (3, 'Video', 'Video post description', 'video1.mp4', @NextMediaElementID + 2, GETDATE(), 'User', 6);
         * 
         * **/

        string createNewSQL = "INSERT INTO Post (userID, postType, postText, mediaFilePath, mediaElementID," 
            + "timeStamp, Category, PostingID) VALUES (1, 'Text', 'This is a new text post.', 'new_text.txt',"
            + "(SELECT IFNULL(MAX(mediaElementID), 0) + 1 FROM Post), '2023-10-26 12:00:00', 'User', 4);";

    }
}
