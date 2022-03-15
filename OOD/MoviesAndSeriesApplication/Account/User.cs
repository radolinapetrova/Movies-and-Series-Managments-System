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

        public User(int id, int typeOfAcc, string name, string username, string password, string email)
            :base(id, typeOfAcc, username, password, email)
        {
            watchlist = new List<Movie>();
        }

        
    }
}
