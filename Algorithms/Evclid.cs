using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Evclid
    {
        static public int NSD(int x, int y)
        {
            if (x < y)
                SelectionSort.swap(ref x, ref y);
            if (x % y == 0)
                return y;
            else 
                return NSD(x % y, y);
        }
    }
}
