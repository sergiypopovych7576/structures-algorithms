using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestLinkedList = global::Structures.LinkedList<string>;

namespace Tests.Structures
{
    public record Car(string Brand, int Quantity);

    public class ListTests
    {
        public TestLinkedList list;
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
            list = new TestLinkedList();
            list.Add(cars[0]);
            list.Add(cars[1]);
            list.Add(cars[2]);
        }

        [Test]
        public void LinkedList_ShouldBeIterable()
        {
            foreach (var car in list)
            {
                Assert.AreEqual(cars[0], car);
                cars.RemoveAt(0);
            }
            Assert.IsFalse(cars.Any());
        }

        [Test]
        public void LinkedList_RemoveAt_ShouldRemoveItem()
        {
            var brands = cars.Where(c => c != "Toyota").ToList();
            list.RemoveAt(1);
            foreach (var car in list)
            {
                Assert.AreEqual(brands[0], car);
                brands.RemoveAt(0);
            }
            Assert.AreEqual(2, list.Size);
        }

        [Test]
        public void LinkedList_Add_ShouldAddItem()
        {
            cars.Add("Volvo");
            list.Add("Volvo");
            foreach (var car in list)
            {
                Assert.AreEqual(cars[0], car);
                cars.RemoveAt(0);
            }
            Assert.AreEqual(4, list.Size);
        }

        [Test]
        public void LinkedList_Insert_ShouldInsertItemAtIndex()
        {
            cars.Insert(1, "Volvo");
            list.Insert(1, "Volvo");
            foreach (var car in list)
            {
                Assert.AreEqual(cars[0], car);
                cars.RemoveAt(0);
            }
            Assert.AreEqual(4, list.Size);
        }
    }
}
