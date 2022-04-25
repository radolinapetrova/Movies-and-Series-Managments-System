using Entities;
using MoviesAndSeriesApplication;
namespace Entities
{
    public class User
    {
        private int id;
        private int typeAcc;
        private string username;
        private string password;
        private string salt;
        private string email;
        private string name;
        private string phoneNumber;
        private Watchlist watchlist;


        public string Password { get { return password; } }
        public string Salt { get { return salt; } }

        public string Email { get { return email; } }

        public string PhoneNumber { get { return phoneNumber; } }

        public int Id { get { return id; } }
        public int TypeAcc { get { return typeAcc; } }
        public string Username { get { return username; } }

        public string Name { get { return name; } }
        

        public Watchlist Watchlist { get { return watchlist; } }



        public User(int id, int typeAcc, string username, string password, string email, string name, string number, string salt)
        {
            this.id = id;
            this.typeAcc = typeAcc;
            this.username = username;
            this.password = password;
            this.email = email;
            this.name = name;
            this.phoneNumber = number;
            this.salt = salt;
        }


        //Seperate constructor for when updating the details of the user
        public User(int id, string username, string password, string number)
        {
            this.username = username;
            this.password = password;
            this.phoneNumber = number;
            this.id = id;
        }

        public void AssignWatchlist(Watchlist watchlist)
        {
            this.watchlist = watchlist;
        }

        public override string ToString()
        {
            return $"ID: {this.Id} Username: {this.Username}";
        }
    }
}
