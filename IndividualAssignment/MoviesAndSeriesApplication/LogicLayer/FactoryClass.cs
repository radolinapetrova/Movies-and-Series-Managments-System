using Entities;
using MoviesAndSeriesApplication;


namespace LogicLayer
{
    public class FactoryClass
    {
        ICRUD<CinematicProduction> moviesDB;
        ICRUD<CinematicProduction> tvshowDB;
        IAutoIncr cpm;
        

        public FactoryClass(ICRUD<CinematicProduction> movieManager, ICRUD<CinematicProduction> tvManager, IAutoIncr cpManager)
        {
            this.tvshowDB = tvManager;
            this.moviesDB = movieManager;
            this.cpm = cpManager;
        }

        public Movie CreateMovie(int id, string name, string description, string releaseDate, int runtime, decimal budget, string streamingPlatform, Image img)
        {
            if (id == 0)
            {
                return new Movie(cpm.GetId(), name, description, releaseDate, runtime, budget, streamingPlatform, img, moviesDB);
            }
            return new Movie(id, name, description, releaseDate, runtime, budget, streamingPlatform, img, moviesDB);
        }

        public TVShow CreateTVShow(int id, string name, string description, string releaseDate, string streamingPlatform, int seasons, int episodes, Image img)
        {
            if (id == 0)
            {
                return new TVShow(cpm.GetId(), name, description, releaseDate, streamingPlatform, seasons, episodes, img, tvshowDB);
            }
            return new TVShow(id, name, description, releaseDate, streamingPlatform, seasons, episodes, img, tvshowDB);
        }
    }
}
