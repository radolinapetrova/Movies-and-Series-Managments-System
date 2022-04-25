using Entities;
using MoviesAndSeriesApplication;

namespace DataAccessLayer
{
    public class CPDBMock : ISort, IAutoIncr
    {
        public List<int> Sort(string sortKey, string order)
        {
            return new List<int>();
        }

        public int GetId()
        {
            return 0;
        }
    }
}
