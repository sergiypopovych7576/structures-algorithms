using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestLinkedList = global::Structures.LinkedList<Tests.Structures.Car>;

namespace Tests.Structures
{
    public record Car(string Brand, int Quantity);

    public class ListTests
    {
        public TestLinkedList list;
        public List<Car> cars = new List<Car>()
        {
            new Car("BMW", 3),
            new Car("Toyota", 2),
            new Car("Mitsubishi", 5)
        };

        [SetUp]
        public void Setup()
        {
            list = new TestLinkedList();
            list.Add(cars[0]);
            list.Add(cars[1]);
            list.Add(cars[2]);
        }

        [Test]
        public void LinkedList_ShouldBeIterable()
        {
            var brands = cars.Select(c => c.Brand).ToList();
            foreach (var car in list)
            {
                Assert.AreEqual(brands[0], car.Brand);
                brands.RemoveAt(0);
            }
            Assert.IsFalse(brands.Any());
        }

        [Test]
        public void LinkedList_RemoveAt_ShouldRemoveItem()
        {
            var brands = cars.Select(c => c.Brand).Where(c => c != "Toyota").ToList();
            list.RemoveAt(1);
            foreach (var car in list)
            {
                Assert.AreEqual(brands[0], car.Brand);
                brands.RemoveAt(0);
            }
            Assert.AreEqual(2, list.Size);
        }

        [Test]
        public void LinkedList_Insert_ShouldInsertItemAtIndex()
        {
            var brands = cars.Select(c => c.Brand).ToList();
            brands.Insert(1, "Volvo");
            list.Insert(1, new Car("Volvo", 5));
            foreach (var car in list)
            {
                Assert.AreEqual(brands[0], car.Brand);
                brands.RemoveAt(0);
            }
            Assert.AreEqual(4, list.Size);
        }
    }
}
