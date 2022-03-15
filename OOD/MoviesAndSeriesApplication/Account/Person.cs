using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public abstract class Person
    {
        private int id;
        private int typeOfAcc;
        private string username;
        private string password;
        private string email;

        public string Password { get { return password; } }
        public string Email { get { return email; } }

        protected Person(int id, int typeOfAcc, string username, string password, string email)
        {
            this.id = id;
            this.typeOfAcc = typeOfAcc;
            this.username = username;
            this.password = password;
            this.email = email;
        }
    }
}
