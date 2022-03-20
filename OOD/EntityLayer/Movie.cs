using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public class Movie : CinematicProduction
    {
        private int runtime;
        private decimal budget;
        

        public Movie(int id, string name, string description, string releaseDate, int runtime, decimal budget, string streamingPlatform)
            :base(id, name, description, releaseDate, streamingPlatform)
        {
            this.runtime = runtime;
            this.budget = budget;
        }

        public int Runtime { get { return runtime; } set { runtime = value; } }
        public decimal Budget { get { return budget; } set { budget = value; } }

        public override string GetInfo()
        {
            return $"Name of the movie:\r\n{base.GetInfo()}";
        }
    }
}
