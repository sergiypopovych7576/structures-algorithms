using NUnit.Framework;
using Algorithms;
using System;

namespace Tests
{
    public class SearchTests
    {
        public int[] array;
        public int searchItem = 4;
        public Predicate<int> searchPredicate;

        [SetUp]
        public void Setup()
        {
            array = new int[]
            {
               1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            searchPredicate = item => item == searchItem;
        }

        [Test]
        public void LinearSearch_ShouldFindItem()
        {
            var res = array.LinearSearch(searchPredicate);
            Assert.AreEqual(searchItem, res);
        }

        [Test]
        public void BinarySearch_ShouldFindItem()
        {
            var res = array.BinarySearch(searchItem);
            Assert.AreEqual(searchItem, res);
        }

        [Test]
        public void BinarySearchRecursive_ShouldFindItem()
        {
            var res = array.BinarySearchRecursive(searchItem);
            Assert.AreEqual(searchItem, res);
        }
    }
}