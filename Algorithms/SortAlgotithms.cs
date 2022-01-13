using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    static class SelectionSort
    {
        static private int MinIndex(int[] arr, int curIndex)
        {
            int resIndex = curIndex;
            for (int i = curIndex; i < arr.Length; i++)
            {
                if (arr[i]<arr[resIndex])
                    resIndex = i;
            }
            return resIndex;
        }
        
        static public void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        static public int[] Sort(int[] array)
        {
            int curIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = MinIndex(array, curIndex);
                if (curIndex != minIndex)
                    swap(ref array[curIndex],ref array[minIndex]);
                curIndex += 1;
            }

            return array;
        }

    }
    //interface QuickSort
    //{
    //    static public List<int> Sort(List<int> array, int indexMin, int indexMax)
    //    {
    //        if (indexMin >= indexMax)
    //            return array;
    //        int pivot = Partition(array, indexMin, indexMax);
    //        Sort(array, indexMin, pivot - 1);
    //        Sort(array, pivot + 1, indexMax);
    //        return array;


    //    }


    //    static abstract int Partition(List<int> array, int indexMin, int indexMax);
    //}

    static class LomutoQuickSort
    {
        static public List<int> Sort(List<int> array, int indexMin, int indexMax)
        {
            if (indexMin>=indexMax)
                return array;
            int pivot = Partition(array, indexMin, indexMax);
            Sort(array, indexMin, pivot-1);
            Sort(array, pivot + 1, indexMax);
            return array;


        }

        static private int Partition(List<int> array, int indexMin, int indexMax)
        {
            int indexPivot = indexMin - 1;
            for (int i = indexMin; i < indexMax; i++)
            {
                if (array[i] < array[indexMax])
                {
                    indexPivot++;
                    Swap(array, i, indexPivot);
                }
            }
            indexPivot++;
            Swap(array, indexPivot, indexMax);
            return indexPivot;
        }

        static public void Swap(List<int> list, int indexA, int indexB)
        {
            int t = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = t;
        }

    }

    static class HoaraQuickSort
    {
        static public List<int> Sort(List<int> array, int indexMin, int indexMax)
        {
            if (indexMin >= indexMax)
                return array;
            int pivot = Partition(array, indexMin, indexMax);
            Sort(array, indexMin, pivot);
            Sort(array, pivot + 1, indexMax);
            return array;


        }

        static private int Partition(List<int> array, int indexMin, int indexMax)
        {
            int PivotValue = (array[indexMin] + array[indexMax]) / 2;
            while (true)
            {
                while (array[indexMin] < PivotValue)
                    indexMin++;
                while (array[indexMax] > PivotValue)
                    indexMax--;
                if (indexMin >= indexMax)
                    return indexMax;
                Swap(array, indexMin, indexMax);
                indexMax--;
                indexMin++;
            }
        }

        static public void Swap(List<int> list, int indexA, int indexB)
        {
            int t = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = t;
        }

    }
}
