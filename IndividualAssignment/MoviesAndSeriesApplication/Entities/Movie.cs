using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoviesAndSeriesApplication;
using Entities;


namespace MoviesAndSeriesApplication
{
    public class Movie : CinematicProduction
    {
        private int runtime;
        private decimal budget;
        

        public Movie(int id, string name, string description, string releaseDate, int runtime, decimal budget, string streamingPlatform, Image img, ICRUD<CinematicProduction> manager)
           : base(id, name, description, releaseDate, streamingPlatform, img, manager)
        {
            this.runtime = runtime;
            this.budget = budget;
        }
        


        public int Runtime { get { return runtime; } }
        public decimal Budget { get { return budget; }  }

        public override string GetInfo()
        {
            return $"Name of the movie:\r\n{base.GetInfo()}";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
