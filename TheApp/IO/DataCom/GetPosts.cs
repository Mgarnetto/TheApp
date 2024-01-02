using System.Data;
using TheApp.Objects;

namespace TheApp.IO.DataCom
{
    public class GetPosts
    {
        public GetPosts()
        {
            // Default constructor
        }

        // Retrieve all posts
        public Post[] GetAll()
        {
            string queryAll = "SELECT * FROM posts ORDER BY timestamp DESC;";
            SSQuery query = new SSQuery();
            DataTable dt = query.Run(queryAll);

            Post[] all = GetObj(dt);
            return all;
        }

        // Retrieve posts by Category and PostingID
        public Post[] GetPostsByCategoryAndID(string category, int postingID)
        {
            string queryString = $"SELECT * FROM posts WHERE Category = '{category}' AND PostingID = {postingID}";
            SSQuery query = new SSQuery(); 
            DataTable dt = query.Run(queryString);

            Post[] posts = GetObj(dt);
            return posts;
        }

        public Post[] GetObj(DataTable dt)
        {
            int size = dt.Rows.Count;
            int it = 0;
            Post[] postArray = new Post[size];

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    int postID = int.Parse(row["postID"].ToString());
                    int userID = int.Parse(row["userID"].ToString());
                    string postType = row["postType"].ToString();
                    string postText = row["postText"].ToString();
                    string mediaFilePath = row["mediaFilePath"].ToString() == null ? "null" : row["mediaFilePath"].ToString();
                    int mediaElementID = string.IsNullOrEmpty(row["mediaElementID"].ToString()) ? 0 : int.Parse(row["mediaElementID"].ToString());

                    DateTime timeStamp = (DateTime)row["timeStamp"];
                    string category = row["Category"].ToString();
                    int postingID = int.Parse(row["PostingID"].ToString());

                    postArray[it] = new Post(postID, userID, postType, postText, mediaFilePath, mediaElementID, timeStamp, category, postingID);
                    it++;
                }
                return postArray;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
