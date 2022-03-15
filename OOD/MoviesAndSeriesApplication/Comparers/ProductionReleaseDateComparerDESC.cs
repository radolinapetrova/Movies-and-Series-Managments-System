using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public class ProductionReleaseDateComparerDESC : IComparer<CinematicProduction>
    {
        public int Compare(CinematicProduction cp1, CinematicProduction cp2)
        {
            int result = cp1.ReleaseDate.CompareTo(cp2.ReleaseDate);

            if (result > 0)
            {
                return -result;
            }
            else if (result < 0)
            {
                return -result;
            }
            return 0;
        }
    }
}
