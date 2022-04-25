using MoviesAndSeriesApplication;
using Entities;

namespace DataAccessLayer
{
    public class MovieDBMock : ICRUD<CinematicProduction>
    {
        public bool Delete(int id)
        {
            return true;
        }

        public bool Add(CinematicProduction cp)
        {
            return true;
        }

        public bool Update(CinematicProduction cp)
        {
            return true;
        }

        public void Read(List<CinematicProduction> cp)
        {
            cp.Add(new Movie(1, "Radi's life", "Kinda depressive, but acceptable.", "2002-12-27", 120, 1000000000, "like everywehere", null, this));
            cp.Add(new Movie(2, "What's the point of life", "idk, but it's fun sometimes", "2022-04-23", 360, 10024738, "reduce, reuse, recycle", null, this));
            cp.Add(new Movie(3, "Why is food the only good thimg in life", "it just never disappoints", "2022-01-17", 180, 2841982468912, "idk at this point", null, this));
            cp.Add(new Movie(4, "How to make money, fast", "contact me if yk", "2022-01-01", 200, 32435383, "hmu i'm desperate", null, this));
        }
    }

}
