using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesAndSeriesApplication;
using Entities;

namespace DataAccessLayer
{
    public class WatchlistDBMock : IWatchlist
    {
        public void Read(User user)
        {
            List<CinematicProduction> watchlist = new List<CinematicProduction>();

            watchlist.Add(new Movie(1, "i'm done with this ...", "i wanna eat sushi", "2012-12-09", 123, 234, "but i already ate a lot", null, new MovieDBMock()));
            watchlist.Add(new TVShow(2, "it got too personal real fast", "i better stop here", "2011-12-23", "thanks for the attention", 12, 134, null, new TVShowDBMock()));

            Watchlist userWL = new Watchlist(watchlist);

            user.AssignWatchlist(userWL);
        }

        public bool Add(User user, CinematicProduction cp)
        {
            return true;
        }

        public bool Delete(User user, CinematicProduction cp)
        {
            return true;
        }
    }
}
