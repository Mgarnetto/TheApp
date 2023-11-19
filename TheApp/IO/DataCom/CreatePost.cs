using System;
using System.Data;
using System.Data.SqlClient;
using TheApp.Objects;

namespace TheApp.IO.DataCom
{
    public class CreatePost
    {
        public CreatePost()
        {
            // Default constructor
        }

        public int InsertPost(Post post)
        {
            string queryString = @"INSERT INTO posts (userID, postType, postText, mediaFilePath, Category, PostingID, timeStamp)
                                   VALUES (@userID, @postType, @postText, @mediaFilePath, @Category, @PostingID, @timeStamp);
                                   SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection("your_connection_string_here"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@userID", post.userID);
                    command.Parameters.AddWithValue("@postType", post.postType);
                    command.Parameters.AddWithValue("@postText", post.postText);
                    command.Parameters.AddWithValue("@mediaFilePath", post.mediaFilePath);
                    command.Parameters.AddWithValue("@Category", post.Category);
                    command.Parameters.AddWithValue("@PostingID", post.PostingID);
                    command.Parameters.AddWithValue("@timeStamp", post.timeStamp);

                    // Execute the query and return the auto-incremented ID
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}
