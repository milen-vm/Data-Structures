namespace CountOfOccurences
{
    using System;
    using System.Collections.Generic;

    class CountOfOccurences
    {
        static void Main()
        {
            Console.WriteLine("Enter sequence of integrs: ");
            string line = Console.ReadLine();

            if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
            {
                SortedDictionary<int, int> numberCount = new SortedDictionary<int, int>();
                string[] elements = line.Split(' ');
                for (int i = 0; i < elements.Length; i++)
                {
                    int number = int.Parse(elements[i]);
                    if(!numberCount.ContainsKey(number))
                    {
                        numberCount.Add(number, 0);
                    }

                    numberCount[number]++;
                }

                foreach (KeyValuePair<int, int> pair in numberCount)
                {
                    Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
