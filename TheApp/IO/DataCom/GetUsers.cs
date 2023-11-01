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
            string queryAll = "SELECT * FROM [user]";
            SSQuery query = new SSQuery();
            DataTable dt = query.Run(queryAll);

            User[] all = GetObj(dt);
            return all;
        }

        public User[] GetUser(int userID)
        {
            string queryAll = "SELECT * FROM [user] where userID = " + userID + ";";
            SSQuery query = new SSQuery();
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

                    userArray[it] = new User(userID, firstName, lastName);
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
