using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestQueue = Structures.Queue<string>;

namespace Tests.Structures
{
    public class QueueTests
    {
        public TestQueue queue;
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
            queue = new TestQueue();
            queue.Enqueue(cars[0]);
            queue.Enqueue(cars[1]);
            queue.Enqueue(cars[2]);
        }

        [Test]
        public void Queue_ShouldBeIterable()
        {
            foreach (var car in queue)
            {
                Assert.AreEqual(cars[0], car);
                cars.RemoveAt(0);
            }
            Assert.IsFalse(cars.Any());
        }

        [Test]
        public void Queue_Enqueue_ShouldAddItemToTheStart()
        {
            queue.Enqueue("Volvo");
            cars.Add("Volvo");
            foreach (var car in queue)
            {
                Assert.AreEqual(cars[0], car);
                cars.RemoveAt(0);
            }
            Assert.AreEqual(4, queue.Size);
        }

        [Test]
        public void Queue_Dequeue_ShouldRemoveItemFromTheEnd()
        {
            queue.Dequeue();
            cars.Remove("BMW");
            foreach (var car in queue)
            {
                Assert.AreEqual(cars[0], car);
                cars.RemoveAt(0);
            }
            Assert.AreEqual(2, queue.Size);
        }

        [Test]
        public void Queue_Top_ShouldReturnItem()
        {
            var item = queue.First();
            Assert.AreEqual("BMW", item);
            Assert.AreEqual(3, queue.Size);
        }
    }
}
