namespace TheApp.Objects
{
    public class User
    {
        public int userID { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? location { get; set; } // such as state/country/etc
        public string? stageName { get; set; } 
        public string? genreLabel { get; set; } // what is the genre of music user makes
        public string? genrePref { get; set; } // what is the genre of music user listens to/prefers



        public User()
        {

        }

        public User(int userID, string firstName, string lastName, string email, string locatiion, string stageName,
            string genreLabel, string genrePref)
        {
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.location = locatiion;
            this.stageName = stageName;
            this.genreLabel = genreLabel;
            this.genrePref = genrePref;
        }
    }
}

