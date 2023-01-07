using Algorithms;
using NUnit.Framework;
using System;

namespace Tests
{
    public class SortingTests
    {
        public int[] array;
        public int[] sortedArray;

        [SetUp]
        public void Setup()
        {
            array = new int[]
            {
               10, 1, 7, 22, 4, 3, 78, 16
            };
            sortedArray = new int[array.Length];
            array.CopyTo(sortedArray, 0);
            Array.Sort(sortedArray);
        }

        [Test]
        public void SelectionSort_ShouldSortArray()
        {
            array.SelectionSort();
            Assert.AreEqual(sortedArray, array);
        }

        [Test]
        public void InsertSort_ShouldSortArray()
        {
            array.InsertSort();
            Assert.AreEqual(sortedArray, array);
        }

        [Test]
        public void BubbleSort_ShouldSortArray()
        {
            array.BubbleSort();
            Assert.AreEqual(sortedArray, array);
        }

        [Test]
        public void ShellSort_ShouldSortArray()
        {
            array.ShellSort();
            Assert.AreEqual(sortedArray, array);
        }

        [Test]
        public void MergeSort_ShouldSortArray()
        {
            array.MergeSort();
            Assert.AreEqual(sortedArray, array);
        }

        [Test]
        public void QuickSort_ShouldSortArray()
        {
            array.QuickSort();
            Assert.AreEqual(sortedArray, array);
        }
    }
}
