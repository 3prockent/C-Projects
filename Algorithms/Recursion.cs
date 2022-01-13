using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Recursion
    {
        static public int Sum(int[] array)
        {
            if (array.Length == 1)
                return array[0];
            else
            {
                var list = new List<int>(array);
                int removed = list[0];
                list.RemoveAt(0);
                array = list.ToArray();
                return removed + Sum(array);
            }
        }

        static private int IntMax(int a, int b)
        {
            if (a > b)
                return a;
            return b;
        }

        static public int ArrayMax(int[] array)
        {
            if (array.Length == 1)
                return array[0];
            return IntMax(array[0], ArrayMax(array.Skip(1).ToArray()));
        }
    }
}
