namespace ArrayBasedStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;
        public int Count { get; private set; }

        public ArrayStack(int capacity)
        {
            this.elements = new T[capacity];
        }

        public ArrayStack()
            : this(InitialCapacity)
        {
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        private void Grow()
        {
            var newElements = new T[2 * this.elements.Length];
            Array.Copy(this.elements, newElements, this.elements.Length);
            this.elements = newElements;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The ArrayStack is empty");
            }

            this.Count--;
            return this.elements[this.Count];
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = this.elements[this.Count - 1 - i];
            }

            return resultArray;
        }
    }
}
