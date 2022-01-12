using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExcel
{

    static public class _26BasedSystem
    {
        public static string To26System(int x)
        {
            x++;
            int mod;
            string columnName = "";
            if (x == 0) return ((char)64).ToString();
            while (x>0)
            {
                mod = (x - 1) % 26;
                columnName = ((char)(65 + mod)).ToString() + columnName;
                x = (x - mod) / 26;
            }
            return columnName;
        }

        public static Tuple<int,int> From26System(string x) //change occur 1AA еtc
        {
            int col = 0;
            int row = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] >= 'A' && x[i] <= 'Z')
                {
                    col *= 26;
                    col += (x[i] - 64);
                }
                else if (x[i] >= '0' && x[i] <= '9')
                {
                    row *= 10;
                    row += (x[i] - 48);
                }
            }
            col -= 1;
            return new Tuple<int, int>(row, col);
        }
    }
}
