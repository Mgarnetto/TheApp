// GetMessages.cs
using System;
using System.Data;
using System.Data.SqlClient;
using TheApp.Objects;

namespace TheApp.IO.DataCom
{
    public class GetMessages
    {
        public GetMessages()
        {
            // Default constructor
        }

        public Message[] GetMessagesByUser(int userID)
        {
            string queryString = $"SELECT * FROM messages WHERE senderID = {userID} OR receiverID = {userID}";
            SSQuery query = new SSQuery(); 
            DataTable dt = query.Run(queryString);

            return GetObj(dt);
        }

        public Message[] GetMyMessages(int userID, int senderID)
        {
            string queryString = $"SELECT * FROM messages WHERE senderID = {senderID} and receiverID = {userID}";
            SSQuery query = new SSQuery(); 
            DataTable dt = query.Run(queryString);

            return GetObj(dt);
        }

        public Message[] GetObj(DataTable dt)
        {
            int size = dt.Rows.Count;
            int it = 0;
            Message[] messageArray = new Message[size];

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    int messageID = int.Parse(row["messageID"].ToString());
                    int senderID = int.Parse(row["senderID"].ToString());
                    int receiverID = int.Parse(row["receiverID"].ToString());
                    int read = int.Parse(row["read"].ToString());
                    int sent = int.Parse(row["sent"].ToString());
                    int deleted = int.Parse(row["deleted"].ToString());
                    string messageText = row["message"].ToString();
                    DateTime dateTime = (DateTime)row["DateTime"];

                    messageArray[it] = new Message(messageID, senderID, receiverID, read, sent, deleted, messageText, dateTime);
                    it++;
                }
                return messageArray;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
