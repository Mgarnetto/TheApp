using System.Data.SqlClient;
using System.Data;

namespace TheApp.IO
{
    public class SSNonQuery
    {
        public DataTable Run(string nonQuery)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConn1.SSConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(nonQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed.
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
