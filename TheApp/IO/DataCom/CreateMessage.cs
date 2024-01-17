using System;
using System.Data.SqlClient;
using TheApp.Objects;

namespace TheApp.IO.DataCom
{
    public class CreateMessage
    {
        public CreateMessage()
        {
            // Default constructor
        }

        public int InsertMessage(Message message)
        {
            string queryString = @"INSERT INTO messages (senderID, receiverID, [read], sent, deleted, message, DateTime)
                                   VALUES (@senderID, @receiverID, @read, @sent, @deleted, @messageText, @DateTime);
                                   SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DBConn1.SSConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@senderID", message.senderID);
                    command.Parameters.AddWithValue("@receiverID", message.receiverID);
                    command.Parameters.AddWithValue("@read", message.read);
                    command.Parameters.AddWithValue("@sent", message.sent);
                    command.Parameters.AddWithValue("@deleted", message.deleted);
                    command.Parameters.AddWithValue("@messageText", message.messageText);
                    command.Parameters.AddWithValue("@DateTime", message.DateTime);

                    // Execute the query and return the auto-incremented ID
                    try
                    {
                        int a = Convert.ToInt32(command.ExecuteScalar());
                        return a;
                    }catch (Exception ex)
                    {
                        string msg = ex.Message;
                    }

                    return 0;
                }
            }
        }
    }
}
