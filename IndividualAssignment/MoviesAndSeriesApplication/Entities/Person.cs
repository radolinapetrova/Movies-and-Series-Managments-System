using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviesAndSeriesApplication
{
    public abstract class Person
    {
        private int id;
        private int typeOfAcc;
        private string username;
        private string password;
        private string email;
        private string name;
        private string phoneNumber;

        [Required]
        public string Password { get { return password; } }
        [Required]
        public string Email { get { return email; } }
        [Required]
        public string PhoneNumber { get { return phoneNumber; } }
        [Required]
        public int Id { get { return id; } }
        [Required]
        public string Username { get { return username; } }

        protected Person(int id, int typeOfAcc, string username, string password, string email, string name, string number)
        {
            this.id = id;
            this.typeOfAcc = typeOfAcc;
            this.username = username;
            this.password = password;
            this.email = email;
            this.name = name;
            this.phoneNumber = number;
        }
    }
}
