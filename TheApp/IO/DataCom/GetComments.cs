namespace TheApp.IO.DataCom
{
    using System;
    using System.Data;
    using TheApp.Objects;

    public class GetComments
    {
        
        // default constructor, because I like typing...
        // c# would've added one by default...
        public GetComments() { 
        // not doing anything in here, right now.
        // this is like class start up, turning the 
        // engine on in the car
        }

        // if you just wanted to get all comments for some reason
        public Comment[] GetAll()
        {
            string queryAll = "SELECT * FROM comments";
            SSQuery query = new SSQuery(); //stuff i made to make querying the db easier
            DataTable dt = query.Run(queryAll);

            Comment[] all = GetObj(dt);
            return all; 
        }

        // getting comments by media element ID, which when we need to load comments 
        // we can first load the post/pic/song/video and then call this method to load 
        // comments by passing it the mediaElementID of that post. It will only load parent 
        // comments and then we will load child or sub comments per parent comment.
        public Comment[] GetCommentByMediaID(int mediaElementID)
        {
            // SQL to load comments where id = id and parent id = null, 
            // meaning it's a top level comment.
            string queryAll = "SELECT * FROM comments WHERE mediaElementID = " + mediaElementID +
                " AND parentCommentID IS NULL ORDER BY timestamp ASC;";

            Query query = new Query();
            DataTable dt = query.Run(queryAll);

            Comment[] all = GetObj(dt); 
            return all;
        }

        public Comment[] GetCommentByMediaID(int mediaElementID, int parentCommentID)
        {
            // SQL to load comments where id = id and parent id = null, 
            // meaning it's a top level comment.
            string queryAll = "SELECT * FROM comments WHERE mediaElementID = " + mediaElementID + 
                " AND parentCommentID = " + parentCommentID + " ORDER BY timestamp ASC;";

            Query query = new Query();
            DataTable dt = query.Run(queryAll);

            Comment[] all = GetObj(dt);
            return all;
        }

        public Comment[] GetObj(DataTable dt)
        {
            int size = dt.Rows.Count; // sets the size of the comment array
            int it = 0; // iterator for comment array while filling it

            Comment[] comArray = new Comment[size]; // comment array to be returned

            try
            {   // extracting each row from the datatable
                foreach (DataRow row in dt.Rows)
                {
                    // extracting data from each data row
                    string commentID = row["commentID"].ToString();
                    string userID = row["userID"].ToString();
                    string mediaElementID = row["mediaElementID"].ToString();
                    // ? used to evaluate if db result is null, if so then set to 0
                    // if it isn't null then set to data from db
                    string parentCommentID = row["parentCommentID"].ToString() == "" ? "0" : row["parentCommentID"].ToString();
                    string commentText = row["commentText"].ToString();
                    DateTime timeStamp = (DateTime)row["timeStamp"];

                    // parsing the numbers 
                    int xCommentID = int.Parse(commentID);
                    int xUserID = int.Parse(userID);
                    int xMediaElementID = int.Parse(mediaElementID);
                    int xParentCommentID = int.Parse(parentCommentID);

                    // creating a comment object for each row 
                    comArray[it] = new Comment(xCommentID,
                        xUserID,
                        xMediaElementID,
                        xParentCommentID,
                        commentText,
                        timeStamp
                        );
                    // increasing iterator for the comment array
                    it++;
                }
                return comArray;
            }
            catch (Exception ex)
            {   // if exception return null aka nothing
                return null;
            }
        }
    }
}
