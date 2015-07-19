namespace ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;

    class ReverseNumbersWithStack
    {
        static void Main()
        {
            Console.Write("Enter count of the integers: ");
            int count = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                Console.Write((i + 1) + " -> ");
                numbers.Push(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}
