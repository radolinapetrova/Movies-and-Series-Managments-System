using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesAndSeriesApplication;
using Entities;

namespace LogicLayer
{
    public class WatchlistManager
    {
        IWatchlist manager;

        public WatchlistManager(IWatchlist manager)
        {
            this.manager = manager; 
        }

        public bool ContainMovie(CinematicProduction cp, User user)
        {
            if (user.Watchlist != null)
            {
                if (user.Watchlist.Productions.Any(CP => CP.Id == cp.Id))
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddToWatchlist(User user, CinematicProduction cp)
        {
            if (!ContainMovie(cp, user))
            {
                if (manager.Add(user, cp))
                {
                    user.Watchlist.AddToWatchlist(cp);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveFromWatchlist(User user, CinematicProduction cp)
        {
            if (manager.Delete(user, cp))
            {
                user.Watchlist.RemoveFromWatchlist(cp);
                return true;
            }
            return false;
        }

        public Watchlist GetWatchlist(User user)
        {
            manager.Read(user);


            return user.Watchlist;
        }
    }
}
