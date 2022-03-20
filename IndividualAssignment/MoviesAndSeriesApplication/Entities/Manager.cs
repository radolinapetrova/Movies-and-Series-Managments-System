using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public class Manager : Person
    {
        private string birthDate;
        private string bsn;

        public Manager(int id, int typeOfAcc, string username, string password, string email, string name, string number, string bd, string bsn)
            :base(id, typeOfAcc, username, password, email, name, number)
        {
           this.birthDate = bd;
            this.bsn = bsn;
        }
    }
}
