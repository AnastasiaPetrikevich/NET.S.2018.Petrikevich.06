using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static JaggetArray.SortsDelegateUsingInterface;

namespace JaggetArray.Tests
{
    [TestFixture]
    public class SortsDelegateUsingInterfaceTests
    {
        [Test]
        public void BublleSort_SortBySum_Increase()
        {
            int[][] actual = { new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3 }, null, new[] { 1, 2, 3, 4, 5 }, new[] { 1 } };
            int[][] expected = { new[] { 1 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4, 5 }, null };
            var comparer = new SortBySumIncrease();
            BublleSort(actual, comparer.Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortBySum_Decrease()
        {
            int[][] actual = { new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3 }, null, new[] { 1, 2, 3, 4, 5 }, new[] { 1 } };
            int[][] expected = { null, new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3 }, new[] { 1 } };
            var comparer = new SortBySumDecrease();
            BublleSort(actual, comparer.Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortByMaxElement_Increase()
        {
            int[][] actual = { new[] { 1, 2, 3, 4 }, new[] { -1, 2, 3 }, null, new[] { 1, 2, 3, -4, 5 }, new[] { 1 } };
            int[][] expected = { new[] { 1 }, new[] { -1, 2, 3 }, new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, -4, 5 }, null };
            var comparer = new SortByMaxElementIncrease();
            BublleSort(actual, comparer.Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortByMaxElement_Decrease()
        {
            int[][] actual = { new[] { 1, 2, 3, 4 }, new[] { -1, 2, 3 }, null, new[] { 1, 3, -4, 5 }, new[] { 1 } };
            int[][] expected = { null, new[] { 1, 3, -4, 5 }, new[] { 1, 2, 3, 4 }, new[] { -1, 2, 3 }, new[] { 1 } };
            var comparer = new SortByMaxElementDecrease();
            BublleSort(actual, comparer.Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortByMinElement_Increase()
        {
            int[][] actual = { new[] { 1, 2, -3, 4 }, new[] { -1, -2, 3 }, null, new[] { 1, 2, 3, -4, 5 }, new[] { 1 } };
            int[][] expected = { new[] { 1 }, new[] { -1, -2, 3 }, new[] { 1, 2, -3, 4 }, new[] { 1, 2, 3, -4, 5 }, null };
            var comparer = new SortByMinElementIncrease();
            BublleSort(actual, comparer.Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortByMinElement_Decrease()
        {
            int[][] actual = { new[] { 1, 2, -3, 4 }, new[] { -1, -2, 3 }, null, new[] { 1, 2, 3, -4, 5 }, new[] { 1 } };
            int[][] expected = { null, new[] { 1, 2, 3, -4, 5 }, new[] { 1, 2, -3, 4 }, new[] { -1, -2, 3 }, new[] { 1 } };
            var comparer = new SortByMinElementDecrease();
            BublleSort(actual, comparer.Compare);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
