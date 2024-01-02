using System;
using System.Data;
using System.Data.SqlClient;
using TheApp.Objects;

namespace TheApp.IO.DataCom
{
    public class GetUserInfo
    {
        public GetUserInfo()
        {
            // Default constructor
        }

        public UserInfo[] GetUserInfosByUserID(int userID)
        {
            string queryString = $"SELECT * FROM Userinfo WHERE userID = {userID}";
            Query query = new Query();
            DataTable dt = query.Run(queryString);

            UserInfo[] userInfos = GetObj(dt);
            return userInfos;
        }

        public UserInfo[] GetObj(DataTable dt)
        {
            int size = dt.Rows.Count;
            int it = 0;
            UserInfo[] userInfoArray = new UserInfo[size];

            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    int userInfoID = int.Parse(row["userInfoID"].ToString());
                    int userID = int.Parse(row["userID"].ToString());
                    string userDOB = row["userDOB"].ToString();
                    string userBio = row["userBio"].ToString();
                    string userAddStreet = row["userAddStreet"].ToString();
                    string userAddCity = row["userAddCity"].ToString();
                    string userAddPostalCode = row["userAddPostalCode"].ToString();
                    string userAddCountry = row["userAddCountry"].ToString();
                    string userMailingAddress = row["userMailingAddress"].ToString();
                    string userAddPhonePersonal = row["userAddPhonePersonal"].ToString();
                    string userAddPhoneBusiness = row["userAddPhoneBusiness"].ToString();

                    userInfoArray[it] = new UserInfo
                    {
                        userInfoID = userInfoID,
                        userID = userID,
                        userDOB = userDOB,
                        userBio = userBio,
                        userAddStreet = userAddStreet,
                        userAddCity = userAddCity,
                        userAddPostalCode = userAddPostalCode,
                        userAddCountry = userAddCountry,
                        userMailingAddress = userMailingAddress,
                        userAddPhonePersonal = userAddPhonePersonal,
                        userAddPhoneBusiness = userAddPhoneBusiness
                    };

                    it++;
                }
                return userInfoArray;
            }
            catch (Exception ex)
            {
                // Handle the exception if needed
                return null;
            }
        }
    }
}
