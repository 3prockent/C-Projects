using System.Collections.Generic;
using System.Linq;
namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SelectionSort
            //var array = new int[10000];
            //for (int i = 0; i < array.Length; i++) 
            //{
            //    array[i] = array.Length - i;
            //}
            //DateTime start = DateTime.Now;
            //SelectionSort.Sort(array);
            //TimeSpan interval =DateTime.Now-start;
            //int lol = (int)interval.TotalMilliseconds;
            //Console.WriteLine(lol);


            //var array2 = new int[80000];
            //for (int i = 0; i < array2.Length; i++)
            //{
            //    array2[i] = array2.Length - i;
            //}
            //start = DateTime.Now;
            //SelectionSort.Sort(array2);
            //interval = DateTime.Now - start;
            //lol = (int)interval.TotalMilliseconds;
            //Console.WriteLine(lol);
            #endregion

            //var array3 = new List<int>();
            //for (int i = 0; i < array3.Count; i++)
            //{
            //    array3[i] = array3.Count - i;
            //}
            //DateTime start = DateTime.Now;

            //TimeSpan interval = DateTime.Now - start;
            //int lol = (int)interval.TotalMilliseconds;
            //for
            //Console.WriteLine(lol);

            //var array = new List<int>() { 3, 6, 2, 6, 3, 54, 46, 74, 2 };
            //QuickSort.Sort(array);
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);

            List<int> fir = new List<int>() { 8,2,6,4,2,7,9,1,8,2,5,7,8,4,6,7};
            HoaraQuickSort.Sort(fir, 0, fir.Count - 1);
            System.Console.WriteLine(string.Join(", ", fir));


        }
       

            

            
       
    }
}
