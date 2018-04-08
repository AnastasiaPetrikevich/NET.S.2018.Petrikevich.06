using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggetArray.Tests
{
    public class SortBySumIncrease : IComparer<int[]>
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null)
                return -1;
            if (rhs == null)
                return 1;
            return -Comparer.SumElements(lhs) + Comparer.SumElements(rhs);
        }
    }

    public class SortBySumDecrease : IComparer<int[]>
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null)
                return 1;
            if (rhs == null)
                return -1;
            return Comparer.SumElements(lhs) - Comparer.SumElements(rhs);
        }
    }

    public class SortByMaxElementIncrease : IComparer<int[]>
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null)
                return -1;
            if (rhs == null)
                return 1;
            return -Comparer.MaxElement(lhs) + Comparer.MaxElement(rhs);
        }
    }

    public class SortByMaxElementDecrease : IComparer<int[]>
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null)
                return 1;
            if (rhs == null)
                return -1;
            return Comparer.MaxElement(lhs) - Comparer.MaxElement(rhs);
        }
    }

    public class SortByMinElementIncrease : IComparer<int[]>
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null)
                return -1;
            if (rhs == null)
                return 1;
            return Comparer.MinElement(lhs) - Comparer.MinElement(rhs);
        }
    }

    public class SortByMinElementDecrease : IComparer<int[]>
    {
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null)
                return 1;
            if (rhs == null)
                return -1;
            return -Comparer.MinElement(lhs) + Comparer.MinElement(rhs);
        }
    }

    public class Comparer
    {
        public static int SumElements(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public static int MaxElement(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public static int MinElement(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
    }
}
