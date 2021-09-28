using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [Test]
        public void Ctor_ThrowsExceptionWhenDBCountIsExcceded()
        {
            Assert.Throws<InvalidOperationException>( () => database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void Ctor_AddValidItems()
        {
            var elements = new int[]{1, 2, 3};
            database = new Database(elements);
            Assert.That(database.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void Add_IncrementCountWhenAddIsValid()
        {
            var n = 5;

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_ThrownExceptionWhenCapacityExceeded()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Remove_DecreaseDBCapacity()
        {
            var n = 3;

            for (int i = 0; i < n; i++)
            {
                database.Add(123);
            }
            database.Remove();
            var expectResultCount = 2;
            Assert.That(database.Count, Is.EqualTo(expectResultCount));
        }

        [Test]
        public void Remove_ThrorwsExceptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_RemovesElementFromDb()
        {
            var n = 3;
            var lastElement = 3;

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            database.Remove();
            var elements = database.Fetch();
            Assert.IsFalse(elements.Contains(lastElement));
        }

        [Test]
        public void Fetch_ReturnsDbCopyNotReference()
        {
            database.Add(1);
            database.Add(2);
            var firstCopy = database.Fetch();
            database.Add(3);
            var secondCopy = database.Fetch();
            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }

        [Test]
        public void Count_ReturnsZeroWhenDbIsEmpty()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }
    }
}