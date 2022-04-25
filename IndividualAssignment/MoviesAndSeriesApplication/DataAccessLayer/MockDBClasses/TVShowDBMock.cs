using MoviesAndSeriesApplication;
using Entities;

namespace DataAccessLayer
{
    public class TVShowDBMock : ICRUD<CinematicProduction>
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
            cp.Add((new TVShow(5, "When it all went downhill", "story of my life", "2016-09-12", "exclusive", 19, 289, null, this)));
            cp.Add(new TVShow(6, "my thoughts", "sometimes might be good, sometimes might be shit", "2010-12-09", "just enjoy", 33, 639, null, this));
            cp.Add(new TVShow(7, "lokk at all those chicekn", "money can literally solve all my problems rn, ngl", "2012-09-30", "i'm a bad b u can't kill me", 12, 176, null, this));
            cp.Add(new TVShow(8, "i wanna eat pasta, but like noww", "am i hungry or am i just bored, that is the question", "2022-04-23", "lola's advice, 50 cents", 1, 1, null, this));
        }
    }
}
