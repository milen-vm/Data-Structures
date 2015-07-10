namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] elements = new T[4];

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }

            private set { }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new InvalidOperationException(string.Format("Index {0} is outside the bounds of the list", index));
                }

                return this.elements[this.Count - 1 - index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new InvalidOperationException(string.Format("Index {0} is outside the bounds of the list", index));
                }

                this.elements[this.Count - 1 - index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count < this.elements.Length)
            {
                this.elements[this.Count] = element;
                this.Count++;
            }
            else if (this.Count == this.elements.Length)
            {
                var newArray = new T[this.Count * 2];
                Array.Copy(this.elements, newArray, this.elements.Length);
                newArray[this.Count] = element;
                this.elements = newArray;
                this.Count++;
            }
            else
            {
                throw new ApplicationException();
            }
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new InvalidOperationException(string.Format("Index {0} is outside the bounds of the list", index));
            }

            int revIndex = this.Count - 1 - index;
            T result = this.elements[revIndex];
            var newArray = new T[this.elements.Length - 1];

            Array.Copy(this.elements, newArray, revIndex);
            Array.Copy(this.elements, revIndex + 1, newArray, revIndex, this.elements.Length - revIndex - 1);

            this.elements = newArray;
            this.Count--;

            return result;
        }


        public IEnumerator<T> GetEnumerator()
        {
            var currentIdex = this.Count - 1;
            while (currentIdex >= 0)
            {
                yield return this.elements[currentIdex];
                currentIdex--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
