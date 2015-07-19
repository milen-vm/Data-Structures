namespace LinkedStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class UnitTestLinkedStack
    {
        [TestMethod]
        public void Create_EmptyLinkedStack_ShouldGetCountZero()
        {
            // Arrange
            var emptyStack = new LinkedStack<int>();

            // Assert
            Assert.AreEqual(0, emptyStack.Count);
        }

        [TestMethod]
        public void Push_EmptyLinkedStack_ShouldAddElement()
        {
            // Arrange
            var emptyStack = new LinkedStack<int>();

            // Act
            emptyStack.Push(5);

            // Assert
            Assert.AreEqual(1, emptyStack.Count);
        }

        [TestMethod]
        public void Pop_LinkedStack_ShouldReturnSameElement()
        {
            // Arrange
            var myStack = new LinkedStack<int>();
            myStack.Push(5);

            // Act
            var result = myStack.Pop();

            // Assert
            Assert.AreEqual(0, myStack.Count);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void PushPop_Grow_ShouldGrowShouldReturnCurrentElement()
        {
            // Arrange
            var myStack = new LinkedStack<string>();
            for (int i = 0; i < 1000; i++)
            {
                // Act
                myStack.Push(i + "");
                // Assert
                Assert.AreEqual(i + 1, myStack.Count);
            }

            for (int i = 999; i >= 0; i--)
            {
                // Act
                var element = myStack.Pop();
                // Assert
                Assert.AreEqual(i, myStack.Count);
                Assert.AreEqual(i + "", element);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyArrayStack_ShouldThrowException()
        {
            var myStack = new LinkedStack<string>();
            myStack.Pop();
        }

        [TestMethod]
        public void PushPop_NonEmptyLinkedStack_ShouldReturnCurrentElementAndCount()
        {
            var myStack = new LinkedStack<int>();
            Assert.AreEqual(0, myStack.Count);

            myStack.Push(5);
            Assert.AreEqual(1, myStack.Count);

            myStack.Push(10);
            Assert.AreEqual(2, myStack.Count);

            var element = myStack.Pop();
            Assert.AreEqual(10, element);
            Assert.AreEqual(1, myStack.Count);

            element = myStack.Pop();
            Assert.AreEqual(5, element);
            Assert.AreEqual(0, myStack.Count);
        }

        [TestMethod]
        public void ConvertToArray_NonEmptyLinkedStack_ShouldReturnReversedElements()
        {
            // Arrange
            var myStack = new LinkedStack<int>();
            myStack.Push(3);
            myStack.Push(5);
            myStack.Push(-2);
            myStack.Push(7);

            // Act
            var resultArray = myStack.ToArray();

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(new int[] { 7, -2, 5, 3 }, resultArray));
        }
    }
}
