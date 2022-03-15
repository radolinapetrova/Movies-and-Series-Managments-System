using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public class ProductionReleaseDateComparerASC : IComparer<CinematicProduction>
    {
        public int Compare(CinematicProduction cp1, CinematicProduction cp2)
        {
            return cp1.ReleaseDate.CompareTo(cp2.ReleaseDate);
        }
    }
}
