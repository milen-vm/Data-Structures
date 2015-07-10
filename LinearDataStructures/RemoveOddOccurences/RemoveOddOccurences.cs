namespace RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveOddOccurences
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

                List<int> evenConunt = new List<int>();
                for (int i = 0; i < numbers.Count; i++)
                {
                    var count = numbers.Count(item => item == numbers[i]);
                    if (count % 2 == 0)
                    {
                        evenConunt.Add(numbers[i]);
                    }
                }

                Console.WriteLine(string.Join(" ", evenConunt));
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
