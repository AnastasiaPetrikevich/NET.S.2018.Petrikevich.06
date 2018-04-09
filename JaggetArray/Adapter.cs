using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggetArray
{
    /// <summary>
    /// Adapts the delegate to the interface.
    /// </summary>
    public class Adapter : IComparer<int[]>
    {
        private Func<int[], int[], int> comparer;

        public Adapter(Func<int[], int[], int> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(int[] lhs, int[] rhs)
        {
            return comparer(lhs, rhs);
        }
    }
}
