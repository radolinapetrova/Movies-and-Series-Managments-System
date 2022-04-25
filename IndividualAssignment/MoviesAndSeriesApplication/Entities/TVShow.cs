using MoviesAndSeriesApplication;
using Entities;

namespace MoviesAndSeriesApplication
{
    public class TVShow : CinematicProduction
    {
        private int seasons;
        private int episodes;

        public int Seasons { get { return seasons; } }
        public int Episodes { get { return episodes; } }


        public TVShow(int id, string name, string description, string releaseDate, string streamingPlatform, int seasons, int episodes, Image img, ICRUD<CinematicProduction> manager)
          : base(id, name, description, releaseDate, streamingPlatform, img, manager)
        {
            this.episodes = episodes;
            this.seasons = seasons;
        }


        public override string GetInfo()
        {
            return $"Name of the TV Show:\r\n{base.GetInfo()}";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
