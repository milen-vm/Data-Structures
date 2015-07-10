namespace LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count == 0)
            {
                this.head = new ListNode<T>(element);
                this.Count++;
            }
            else
            {
                var lastNode = this.head;
                while (true)
                {
                    if (lastNode.NextNode == null)
                    {
                        break;
                    }

                    lastNode = lastNode.NextNode;
                }

                var newLastNode = new ListNode<T>(element);
                lastNode.NextNode = newLastNode;
                this.Count++;
            }
        }

        public T Remove(int index)
        {
            if (index > this.Count - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("Index {0} is outside the bounds of the list", index));
            }

            ListNode<T> prevNode = null;
            ListNode<T> currNode = this.head;
            for (int i = 1; i <= index; i++)
            {
                prevNode = currNode;
                currNode = currNode.NextNode;
            }

            if (prevNode == null)
            {
                this.head = currNode.NextNode;
            }
            else
            {
                prevNode.NextNode = currNode.NextNode;
            }

            this.Count--;

            return currNode.Value;
        }

        public int FristIdexOf(T item)
        {
            int index = -1;
            var currentNode = this.head;
            int currentIndex = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    index = currentIndex;
                    break;
                }

                currentNode = currentNode.NextNode;
                ++currentIndex;
            }

            return index;
        }

        public int LastIndexOf(T item)
        {
            int index = -1;
            var currentNode = this.head;
            int currentIndex = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    index = currentIndex;
                }

                currentNode = currentNode.NextNode;
                ++currentIndex;
            }

            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
