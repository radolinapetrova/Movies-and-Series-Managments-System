using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public class Manager : Person
    {
        private string firstName;
        private string lastName;

        public Manager(int id, int typeOfAcc, string name, string username, string password, string email, string firstName, string lastName)
            :base(id, typeOfAcc, username, password, email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
