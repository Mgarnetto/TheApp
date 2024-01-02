namespace TheApp.Objects
{
    public class UserInfo
    {
        public int userInfoID { get; set; }
        public int userID { get; set; }
        public string? userDOB { get; set; }
        public string? userBio { get; set; }
        public string? userAddStreet { get; set; }
        public string? userAddCity { get; set; }
        public string? userAddPostalCode { get; set; }
        public string? userAddCountry { get; set; }
        public string? userMailingAddress { get; set; }
        public string? userAddPhonePersonal { get; set; }
        public string? userAddPhoneBusiness { get; set; }

        public UserInfo()
        {
           
        }

        public UserInfo(int userID, string userDOB, string userBio,
            string userAddStreet, string userAddCity, string userAddPostalCode,
            string userAddCountry, string userMailingAddress, string userAddPhonePersonal,
            string userAddPhoneBusiness)
        {
            this.userID = userID;
            this.userDOB = userDOB;
            this.userBio = userBio;
            this.userAddStreet = userAddStreet;
            this.userAddCity = userAddCity;
            this.userAddPostalCode = userAddPostalCode;
            this.userAddCountry = userAddCountry;
            this.userMailingAddress = userMailingAddress;
            this.userAddPhonePersonal = userAddPhonePersonal;
            this.userAddPhoneBusiness = userAddPhoneBusiness;
        }
    }
}

