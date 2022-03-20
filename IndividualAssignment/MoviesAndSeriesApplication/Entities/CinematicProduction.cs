using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public abstract class CinematicProduction : IComparable<CinematicProduction>
    {
        private string name;
        private string description;
        private string releaseDate;
        private string streamingPlatform;
        private int id;
        

        public string Name { get { return name; } set { name = value; } }
        public string ReleaseDate { get { return releaseDate; } set{ releaseDate = value; } }
        public string StreamingPlatform { get { return streamingPlatform; } set { streamingPlatform = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int Id { get { return id; } }

        protected CinematicProduction(int id, string name, string description, string releaseDate, string streamingPlatform)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.releaseDate = releaseDate;
            this.streamingPlatform = streamingPlatform;
        }

        public virtual string GetInfo()
        {
            return $"{this.name}\r\n\r\nDescription: \r\n{this.description}";
        }
        
        public int CompareTo(CinematicProduction cp)
        {
            return this.Name.CompareTo(cp.Name);
        }
        
    }
}
