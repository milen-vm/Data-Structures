namespace LinkedQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class UnitTestLinkedQueue
    {
        [TestMethod]
        public void Create_EmptyLinkedQueue_ShouldGetCountZero()
        {
            // Arrange
            var emptyQueue = new LinkedQueue<int>();

            // Assert
            Assert.AreEqual(0, emptyQueue.Count);
        }

        [TestMethod]
        public void Enqueue_LinkedLinkedQueue_ShouldAddElement()
        {
            // Arrange
            var myQueue = new LinkedQueue<int>();

            // Act
            myQueue.Enqueue(5);

            // Assert
            Assert.AreEqual(1, myQueue.Count);
        }

        [TestMethod]
        public void Dequeue_LinkedQueue_ShouldReturnSameElement()
        {
            // Arrange
            var myQueue = new LinkedQueue<int>();
            myQueue.Enqueue(5);

            // Act
            var result = myQueue.Dequeue();

            // Assert
            Assert.AreEqual(0, myQueue.Count);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void EnqueueDequeue_Grow_ShouldReturnCurrentElement()
        {
            // Arrange
            var myQueue = new LinkedQueue<string>();
            for (int i = 0; i < 1000; i++)
            {
                // Act
                myQueue.Enqueue(i + "");
                // Assert
                Assert.AreEqual(i + 1, myQueue.Count);
            }

            for (int i = 0; i < 1000; i++)
            {
                // Act
                var element = myQueue.Dequeue();
                // Assert
                Assert.AreEqual(1000 - i - 1, myQueue.Count);
                Assert.AreEqual(i + "", element);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyLinkedQueue_ShouldThrowException()
        {
            var myQueue = new LinkedQueue<string>();
            myQueue.Dequeue();
        }

        [TestMethod]
        public void EnqueueDequeue_NonEmptyLinkedQueue_ShouldReturnCurrentElementAndCount()
        {
            var myQueue = new LinkedQueue<int>();
            Assert.AreEqual(0, myQueue.Count);

            myQueue.Enqueue(5);
            Assert.AreEqual(1, myQueue.Count);

            myQueue.Enqueue(10);
            Assert.AreEqual(2, myQueue.Count);

            var element = myQueue.Dequeue();
            Assert.AreEqual(5, element);
            Assert.AreEqual(1, myQueue.Count);

            element = myQueue.Dequeue();
            Assert.AreEqual(10, element);
            Assert.AreEqual(0, myQueue.Count);
        }

        [TestMethod]
        public void ConvertToArray_NonEmptyLinkedQueue_ShouldReturnElementsArray()
        {
            // Arrange
            var myQueue = new LinkedQueue<int>();
            myQueue.Enqueue(3);
            myQueue.Enqueue(5);
            myQueue.Enqueue(-2);
            myQueue.Enqueue(7);

            // Act
            var resultArray = myQueue.ToArray();

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(new int[] { 3, 5, -2, 7 }, resultArray));
        }
    }
}
