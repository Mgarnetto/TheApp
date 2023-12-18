using System;
using System.Data;
using System.Data.SqlClient;

namespace TheApp.IO.DataCom
{
    public class CreateFile
    {
        public CreateFile()
        {
            // Default constructor
        }

        public int InsertFile(TheApp.Objects.File file)
        {
            string queryString = @"INSERT INTO [File] (userID, fileName, fileTitle, fileServer, filePath, fileType, modifiedDateTime)
                                   VALUES (@userID, @fileName, @fileTitle, @fileServer, @filePath, @fileType, @modifiedDateTime);
                                   SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DBConn1.SSConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@userID", file.userID);
                    command.Parameters.AddWithValue("@fileName", file.fileName);
                    command.Parameters.AddWithValue("@fileTitle", file.fileTitle);
                    command.Parameters.AddWithValue("@fileServer", file.fileServer);
                    command.Parameters.AddWithValue("@filePath", file.filePath);
                    command.Parameters.AddWithValue("@fileType", file.fileType);
                    command.Parameters.AddWithValue("@modifiedDateTime", file.modifiedDateTime);

                    // Execute the query and return the auto-incremented ID
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}
