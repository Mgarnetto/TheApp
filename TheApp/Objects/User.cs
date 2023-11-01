namespace TheApp.Objects
{
    public class User
    {
        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public User()
        {

        }

        public User(int userID, string firstName, string lastName)
        {
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}

