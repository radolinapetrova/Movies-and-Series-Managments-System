using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndSeriesApplication
{
    public class ProductionNameComparer : IComparer<CinematicProduction>
    {
        public int Compare(CinematicProduction cp1, CinematicProduction cp2)
        {
            int result = cp1.Name.CompareTo(cp2.Name);

            if (result > 0)
            {
                return -result;
            }
            else if (result < 0)
            {
                result = -result;
            }

            return result;
        }
    }
}
