using System.Data;
using System.Data.SqlClient;
using TheApp.Objects;

namespace TheApp.IO.DataCom
{
    public class CreateComment
    {
        public CreateComment()
        {
            // Default constructor
        }

        public int InsertComment(Comment comment)
        {
            string queryString = @"INSERT INTO comments (userID, mediaElementID, parentCommentID, commentText, timeStamp)
                                   VALUES (@userID, @mediaElementID, @parentCommentID, @commentText, @timeStamp);
                                   SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection("your_connection_string_here"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@userID", comment.userID);
                    command.Parameters.AddWithValue("@mediaElementID", comment.mediaElementID);
                    command.Parameters.AddWithValue("@parentCommentID", comment.parentCommentID);
                    command.Parameters.AddWithValue("@commentText", comment.commentText);
                    command.Parameters.AddWithValue("@timeStamp", comment.timeStamp);

                    // Execute the query and return the auto-incremented ID
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}
