namespace SequenceNtoM
{
    using System;
    using System.Collections.Generic;

    class SequenceNtoM
    {
        static void Main()
        {
            Console.Write("Enter integer N: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Enter integer M: ");
            int end = int.Parse(Console.ReadLine());

            Queue<Node<int>> sequence = new Queue<Node<int>>();
            sequence.Enqueue(new Node<int>(start));

            while (sequence.Count > 0)
            {
                var item = sequence.Dequeue();
                if (item.Value < end)
                {
                    sequence.Enqueue(new Node<int>(item.Value + 1, item));
                    sequence.Enqueue(new Node<int>(item.Value + 2, item));
                    sequence.Enqueue(new Node<int>(item.Value * 2, item));
                }
                else if (item.Value == end)
                {
                    PrintOutput(item);
                    return;
                }
            }

            Console.WriteLine("(no solution)");
        }

        private static void PrintOutput(Node<int> item)
        {
            var numbers = new Stack<int>();
            var currentItem = item;
            while (currentItem != null)
            {
                numbers.Push(currentItem.Value);
                currentItem = currentItem.PrevNode;
            }

            Console.WriteLine(string.Join(" -> ", numbers));
        }

        private class Node<T>
        {
            public T Value { get; private set; }
            public Node<T> PrevNode { get; private set; }

            public Node(T value, Node<T> prevNode = null)
            {
                this.Value = value;
                this.PrevNode = prevNode;
            }
        }
    }
}
