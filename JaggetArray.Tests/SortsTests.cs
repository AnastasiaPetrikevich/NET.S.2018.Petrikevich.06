using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JaggetArray;
using NUnit.Framework.Interfaces;

namespace JaggetArray.Tests
{
    [TestFixture]
    public class SortsTests
    {
        [Test]
        public void BublleSort_SortBySum_Increase()
        {
            int[][] actual = { new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3 }, null, new[] { 1, 2, 3, 4, 5 }, new[] { 1 } };
            int[][] expected = { new[] { 1 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4, 5 }, null };
            Sorts.BublleSort(actual, new SortBySumIncrease());
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortBySum_Decrease()
        {
            int[][] actual = { new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3 }, null, new[] { 1, 2, 3, 4, 5 }, new[] { 1 } };
            int[][] expected = { null, new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3 }, new[] { 1 } };
            Sorts.BublleSort(actual, new SortBySumDecrease());
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortByMaxElement_Increase()
        {
            int[][] actual = { new[] { 1, 2, 3, 4 }, new[] { -1, 2, 3 }, null, new[] { 1, 2, 3, -4, 5 }, new[] { 1 } };
            int[][] expected = { new[] { 1 }, new[] { -1, 2, 3 }, new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, -4, 5 }, null };
            Sorts.BublleSort(actual, new SortByMaxElementIncrease());
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortByMaxElement_Decrease()
        {
            int[][] actual = { new[] { 1, 2, 3, 4 }, new[] { -1, 2, 3 }, null, new[] { 1, 3, -4, 5 }, new[] { 1 } };
            int[][] expected = { null, new[] { 1, 3, -4, 5 }, new[] { 1, 2, 3, 4 }, new[] { -1, 2, 3 }, new[] { 1 } };
            Sorts.BublleSort(actual, new SortByMaxElementDecrease());
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortByMinElement_Increase()
        {
            int[][] actual = { new[] { 1, 2, -3, 4 }, new[] { -1, -2, 3 }, null, new[] { 1, 2, 3, -4, 5 }, new[] { 1 } };
            int[][] expected = { new[] { 1 }, new[] { -1, -2, 3 }, new[] { 1, 2, -3, 4 }, new[] { 1, 2, 3, -4, 5 }, null };
            Sorts.BublleSort(actual, new SortByMaxElementIncrease());
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BublleSort_SortByMinElement_Decrease()
        {
            int[][] actual = { new[] { 1, 2, -3, 4 }, new[] { -1, -2, 3 }, null, new[] { 1, 2, 3, -4, 5 }, new[] { 1 } };
            int[][] expected = { null, new[] { 1, 2, 3, -4, 5 }, new[] { 1, 2, -3, 4 }, new[] { -1, -2, 3 }, new[] { 1 } };
            Sorts.BublleSort(actual, new SortByMaxElementDecrease());
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
