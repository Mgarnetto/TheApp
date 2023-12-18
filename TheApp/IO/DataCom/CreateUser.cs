using System;
using System.Data;
using System.Data.SqlClient;
using TheApp.Objects;

namespace TheApp.IO.DataCom
{
    public class CreateUser
    {
        public CreateUser()
        {
            // Default constructor
        }

        public int InsertUser(User user)
        {
            try
            {
                string queryString = @"INSERT INTO users (firstName, lastName, email, location, stageName, genreLabel, genrePref) 
                                       VALUES (@FirstName, @LastName, @Email, @Location, @StageName, @GenreLabel, @GenrePref);
                                       SELECT SCOPE_IDENTITY();";

                using (SqlConnection connection = new SqlConnection(DBConn1.SSConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", user.firstName);
                        command.Parameters.AddWithValue("@LastName", user.lastName);
                        command.Parameters.AddWithValue("@Email", user.email);
                        command.Parameters.AddWithValue("@Location", user.location);
                        command.Parameters.AddWithValue("@StageName", user.stageName);
                        command.Parameters.AddWithValue("@GenreLabel", user.genreLabel);
                        command.Parameters.AddWithValue("@GenrePref", user.genrePref);

                        // Execute the query and return the auto-incremented ID
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log, or rethrow as needed
                Console.WriteLine($"Error inserting user: {ex.Message}");
                return -1; // Return an error code
            }
        }
    }
}
