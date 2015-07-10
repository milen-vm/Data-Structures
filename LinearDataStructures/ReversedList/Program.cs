namespace ReversedList
{
    using System;

    class Program
    {
        static void Main()
        {
            var rev = new ReversedList<int>();
            rev.Add(1);
            rev.Add(2);
            rev.Add(3);
            rev.Add(4);
            rev.Add(5);

            foreach (var item in rev)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("Count " + rev.Count);
            Console.WriteLine("Capacity " + rev.Capacity);
            Console.WriteLine("Element on index 0 -> " + rev[0]);
            Console.WriteLine("Remove element on index 0 -> " + rev.Remove(0));
            Console.WriteLine("Count " + rev.Count);
            Console.WriteLine("Capacity " + rev.Capacity);
            Console.WriteLine();
            rev[0] = 10;
            for (int i = 0; i < rev.Count; i++)
            {
                Console.WriteLine(rev[i]);
            }
        }
    }
}
