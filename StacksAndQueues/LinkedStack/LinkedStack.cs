namespace LinkedStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;
        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new Node<T>(element);
            }
            else
            {
                var oldNode = this.firstNode;
                this.firstNode = new Node<T>(element, oldNode);
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The LinkedStack is empty");
            }

            var result = this.firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return result.Value;
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            var currentNode = this.firstNode;
            int index = 0;
            while (currentNode != null)
            {
                resultArray[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                ++index;
            }

            return resultArray;
        }

        private class Node<T>
        {
            public T Value  {get; private set; }
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }
    }
}
