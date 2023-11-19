using TheApp.Objects;
using System.Data;
using File = TheApp.Objects.File;

namespace TheApp.IO.DataCom
{
    public class GetFiles
    {
        public GetFiles()
        {
            // Default constructor
        }

        // Retrieve all files
        public TheApp.Objects.File[] GetAll()
        {
            string queryAll = "SELECT * FROM [File]";
            Query query = new Query();
            DataTable dt = query.Run(queryAll);

            TheApp.Objects.File[] all = GetObj(dt);
            return all;
        }

        // Retrieve files by UserID
        public TheApp.Objects.File[] GetFilesByUserID(int userID)
        {
            string queryString = $"SELECT * FROM [File] WHERE userID = {userID}";
            Query query = new Query();
            DataTable dt = query.Run(queryString);

            TheApp.Objects.File[] files = GetObj(dt);
            return files;
        }

        public TheApp.Objects.File[] GetObj(DataTable dt)
        {
            int size = dt.Rows.Count;
            int it = 0;
            TheApp.Objects.File[] fileArray = new TheApp.Objects.File[size];

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    int fileID = int.Parse(row["fileID"].ToString());
                    int userID = int.Parse(row["userID"].ToString());
                    string fileName = row["fileName"].ToString();
                    string fileTitle = row["fileTitle"].ToString();
                    string fileServer = row["fileServer"].ToString();
                    string filePath = row["filePath"].ToString();
                    string fileType = row["fileType"].ToString();
                    DateTime modifiedDateTime = (DateTime)row["modifiedDateTime"];

                    fileArray[it] = new TheApp.Objects.File(fileID, userID, fileName, fileTitle, fileServer, filePath, fileType, modifiedDateTime);
                    it++;
                }
                return fileArray;
            }
            catch (Exception ex)
            {
                // Handle exception as needed
                return null;
            }
        }
    }
}
