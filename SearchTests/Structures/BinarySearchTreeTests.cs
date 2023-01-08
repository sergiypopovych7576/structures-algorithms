using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestBinarySearchTree = Structures.BinarySearchTree<int>;

namespace Tests.Structures
{
    public class BinarySearchTreeTests
    {
        public TestBinarySearchTree tree;
        public List<int> numbers;

        [SetUp]
        public void Setup()
        {
            numbers = new List<int>()
            {
              8, 10, 5, 3, 6, 9, 13
            };
            tree = new TestBinarySearchTree();
            foreach (var number in numbers)
            {
                tree.Insert(number);
            }
        }

        [Test]
        public void BinarySearchTree_ShouldBeIterable()
        {
            var expectedNumbers = new List<int>()
            {
                3, 5, 6, 8, 9, 10, 13
            };
            foreach (var number in tree)
            {
                Assert.AreEqual(expectedNumbers[0], number);
                expectedNumbers.RemoveAt(0);
            }
            Assert.IsFalse(expectedNumbers.Any());
        }

        [Test]
        public void BinarySearchTree_Search_ShouldReturnItem()
        {
            var foundItem = tree.Search(item => item == 13);
            Assert.AreEqual(13, foundItem);
        }

        [Test]
        public void BinarySearchTree_Search_ShouldNotReturnItem_WhenNotExists()
        {
            var foundItem = tree.Search(item => item == 55);
            Assert.AreEqual(0, foundItem);
        }
    }
}
