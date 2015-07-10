namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SumAndAverage
    {
        static void Main()
        {
            Console.WriteLine("Enter sequence of integrs: ");
            string line = Console.ReadLine();

            if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
            {
                List<int> numbers = new List<int>();
                string[] elements = line.Split(' ');
                for (int i = 0; i < elements.Length; i++)
                {
                    numbers.Add(int.Parse(elements[i]));
                }

                int sum = numbers.Sum();
                double avg = numbers.Average();

                Console.WriteLine("Sum={0}; Average={1}", sum, avg);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
