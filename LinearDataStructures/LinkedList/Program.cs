namespace LinkedList
{
    using System;

    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(2);
            list.Add(2);

            Console.WriteLine("Count -> " + list.Count);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Remoeved at index 0 -> " + list.Remove(0));
            Console.WriteLine("Count -> " + list.Count);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("First index of 2 -> " + list.FristIdexOf(2));
            Console.WriteLine("Last index of 2 -> " + list.LastIndexOf(2));
        }
    }
}
