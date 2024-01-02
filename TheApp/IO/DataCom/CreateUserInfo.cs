using System;
using System.Data.SqlClient;
using TheApp.Objects;

namespace TheApp.IO.DataCom
{
    public class CreateUserInfo
    {
        public CreateUserInfo()
        {
            // Default constructor
        }

        public int InsertUserInfo(UserInfo userInfo)
        {
            string queryString = @"INSERT INTO Userinfo (userID, userDOB, userBio, userAddStreet, userAddCity, 
                                                userAddPostalCode, userAddCountry, userMailingAddress, 
                                                userAddPhonePersonal, userAddPhoneBusiness)
                                   VALUES (@userID, @userDOB, @userBio, @userAddStreet, @userAddCity, 
                                           @userAddPostalCode, @userAddCountry, @userMailingAddress, 
                                           @userAddPhonePersonal, @userAddPhoneBusiness);
                                   SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(DBConn1.SSConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@userID", userInfo.userID);
                    command.Parameters.AddWithValue("@userDOB", userInfo.userDOB);
                    command.Parameters.AddWithValue("@userBio", userInfo.userBio);
                    command.Parameters.AddWithValue("@userAddStreet", userInfo.userAddStreet);
                    command.Parameters.AddWithValue("@userAddCity", userInfo.userAddCity);
                    command.Parameters.AddWithValue("@userAddPostalCode", userInfo.userAddPostalCode);
                    command.Parameters.AddWithValue("@userAddCountry", userInfo.userAddCountry);
                    command.Parameters.AddWithValue("@userMailingAddress", userInfo.userMailingAddress);
                    command.Parameters.AddWithValue("@userAddPhonePersonal", userInfo.userAddPhonePersonal);
                    command.Parameters.AddWithValue("@userAddPhoneBusiness", userInfo.userAddPhoneBusiness);

                    // Execute the query and return the auto-incremented ID
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}
