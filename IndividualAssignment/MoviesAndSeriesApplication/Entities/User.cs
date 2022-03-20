using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public class User : Person
    {
        private List<Movie> watchlist;

        public User(int id, int typeOfAcc, string username, string password, string email, string name, string number)
            :base(id, typeOfAcc, username, password, email, name, number)
        {
            watchlist = new List<Movie>();
        }

        
    }
}
