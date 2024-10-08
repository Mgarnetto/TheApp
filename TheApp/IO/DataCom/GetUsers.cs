using System;
using System.Data;
using TheApp.IO;
using TheApp.Objects;

namespace TheApp.IO.DataCom
{
    public class GetUsers
    {
        public GetUsers()
        {
            // Default constructor
        }

        // Retrieve all users
        public User[] GetAll()
        {
            string queryAll = "SELECT * FROM users";
            //SSQuery query = new SSQuery();
            Query query = new Query();
            DataTable dt = query.Run(queryAll);

            User[] all = GetObj(dt);
            return all;
        }

        public User[] GetUser(int userID)
        {
            //string queryAll = "SELECT * FROM user;";
            string queryAll = "SELECT * FROM users WHERE userID = " + userID + ";";
            //string queryAll = "SELECT * FROM [user] where userID = " + userID + ";";
            //SSQuery query = new SSQuery();
            Query query = new Query();
            DataTable dt = query.Run(queryAll);

            User[] theOneUser = GetObj(dt);
            return theOneUser;
        }

        public User[] GetObj(DataTable dt)
        {
            int size = dt.Rows.Count;
            int it = 0;
            User[] userArray = new User[size];

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    int userID = int.Parse(row["userID"].ToString());
                    string firstName = row["firstName"].ToString();
                    string lastName = row["lastName"].ToString();
                    string email = row["email"].ToString();
                    string location = row["location"].ToString();
                    string stageName = row["stageName"].ToString();
                    string genreLabel = row["genreLabel"].ToString();
                    string genrePref = row["genrePref"].ToString();

                    userArray[it] = new User(userID, firstName, lastName, email, location, stageName,
                        genreLabel, genrePref);
                    it++;
                }
                return userArray;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
