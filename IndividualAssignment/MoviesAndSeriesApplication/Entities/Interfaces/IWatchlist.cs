using MoviesAndSeriesApplication;
using Entities;

namespace Entities
{
    public interface IWatchlist
    {
        public void Read(User user);

        public bool Add(User user, CinematicProduction cp);


        public bool Delete(User user, CinematicProduction cp);
    }
}
