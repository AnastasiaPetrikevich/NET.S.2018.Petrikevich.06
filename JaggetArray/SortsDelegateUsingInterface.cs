using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggetArray
{
    /// <summary>
    /// Contains methods for work whith jagget arrays.
    /// </summary>
    public static class SortsDelegateUsingInterface
    {
        public delegate int Comparer(int[] firstArray, int[] secondArray);

        /// <summary>
        /// Sorts jagget array using interface.
        /// </summary>
        /// <param name="array">Jagget array.</param>
        /// <param name="comparer">How sorts</param>
        public static void BublleSort(int[][] array, IComparer<int[]> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparer.Compare(array[j + 1], array[j]) > 0)
                    {
                        Swap(ref array[j + 1], ref array[j]);
                    }
                }
            }

        }

        /// <summary>
        /// Sorts jagget array using delegate.
        /// </summary>
        /// <param name="array">Jagget array.</param>
        /// <param name="comparer">How sorts</param>
        public static void BublleSort(int[][] array, Comparer comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            IComparer<int[]> newComparer = comparer.Target as IComparer<int[]>;
            BublleSort(array, newComparer);
        }

        /// <summary>
        /// Swaps two arrays.
        /// </summary>
        /// <param name="first">First array.</param>
        /// <param name="second">Second array.</param>
        static void Swap(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
    }
}

