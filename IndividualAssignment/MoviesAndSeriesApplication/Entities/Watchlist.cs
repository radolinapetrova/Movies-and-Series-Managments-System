using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MoviesAndSeriesApplication;

namespace Entities
{
    public class Watchlist
    {
        private List<CinematicProduction> productions;


        public IList<CinematicProduction> Productions { get { return productions; } }

        public Watchlist(List<CinematicProduction> productions)
        {
            this.productions = productions;
        }


        public void AddToWatchlist(CinematicProduction cp)
        {
            productions.Add(cp);
        }

        public void RemoveFromWatchlist(CinematicProduction cp)
        {
            productions.Remove(cp);
        }


    }
}
