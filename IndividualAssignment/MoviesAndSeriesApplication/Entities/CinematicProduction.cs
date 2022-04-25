using Entities;

namespace MoviesAndSeriesApplication
{
    public abstract class CinematicProduction 
    {
        private string name;
        private string description;
        private string releaseDate;
        private string streamingPlatform;
        private int id;
        private Image img;
        private ICRUD<CinematicProduction> manager;
        

        public string Name { get { return name; }  }
        public string ReleaseDate { get { return releaseDate; }  }
        public string StreamingPlatform { get { return streamingPlatform; } }
        public string Description { get { return description; } }
        public int Id { get { return id; } }
        public Image Image { get { return img; } }
        public ICRUD<CinematicProduction> Manager { get { return manager; } }


        protected CinematicProduction(int id, string name, string description, string releaseDate, string streamingPlatform, Image img, ICRUD<CinematicProduction> manager)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.releaseDate = releaseDate;
            this.streamingPlatform = streamingPlatform;
            this.img = img;
            this.manager = manager;
        }


        public virtual string GetInfo()
        {
            return $"{this.name}\r\n\r\nDescription: \r\n{this.description}";
        }

        public override string ToString()
        {
            return $"ID: {this.Id}\tName: {this.Name}";
        }


    }
}
