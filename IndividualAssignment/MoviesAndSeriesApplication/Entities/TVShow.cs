using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public class TVShow : CinematicProduction
    {
        private int seasons;
        private int episodes;

        public int Seasons { get { return seasons; } set { seasons = value; } }
        public int Episodes { get { return episodes; } set { episodes = value; } }

        public TVShow(int id, string name, string description, string releaseDate, string streamingPlatform, int seasons, int episodes)
           :base(id, name, description, releaseDate, streamingPlatform)
        {
            this.episodes = episodes;
            this.seasons = seasons;
        }

        public override string GetInfo()
        {
            return $"Name of the TV Show:\r\n{base.GetInfo()}";
        }
    }
}
