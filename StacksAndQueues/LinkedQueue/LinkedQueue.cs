namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> firstNode;
        private QueueNode<T> lastNode;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = this.lastNode = new QueueNode<T>(element);
            }
            else
            {
                var newLastNode = new QueueNode<T>(element);
                newLastNode.PrevNode = this.lastNode;
                this.lastNode.NextNode = newLastNode;
                this.lastNode = newLastNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The LinkedQueue is empty");
            }

            var firstElement = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;

            if (this.firstNode != null)
            {
                this.firstNode.PrevNode = null;
            }
            else
            {
                this.lastNode = null;
            }

            this.Count--;

            return firstElement;
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            var currentNode = this.firstNode;
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

                return resultArray;
        }

        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode(T value)
            {
                this.Value = value;
            }
        }
    }
}
