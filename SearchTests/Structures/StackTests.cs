using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack = Structures.Stack<string>;

namespace Tests.Structures
{
    public class StackTests
    {
        public TestStack stack;
        public List<string> cars;

        [SetUp]
        public void Setup()
        {
            cars = new List<string>()
            {
               "BMW",
               "Toyota",
               "Mitsubishi"
            };
            stack = new TestStack();
            stack.Push(cars[0]);
            stack.Push(cars[1]);
            stack.Push(cars[2]);
        }

        [Test]
        public void Stack_ShouldBeIterable()
        {
            cars.Reverse();
            foreach (var car in stack)
            {
                Assert.AreEqual(cars[0], car);
                cars.RemoveAt(0);
            }
            Assert.IsFalse(cars.Any());
        }

        [Test]
        public void Stack_Pop_ShouldReturnAndRemoveItem()
        {
            var item = stack.Pop();
            Assert.AreEqual("Mitsubishi", item);
            item = stack.Pop();
            Assert.AreEqual("Toyota", item);
            Assert.AreEqual(1, stack.Size);
        }

        [Test]
        public void Stack_Top_ShouldReturnItem()
        {
            var item = stack.Top();
            Assert.AreEqual("Mitsubishi", item);
            Assert.AreEqual(3, stack.Size);
        }
    }
}
