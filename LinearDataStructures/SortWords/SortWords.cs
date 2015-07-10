namespace SortWords
{
    using System;
    using System.Collections.Generic;

    class SortWords
    {
        static void Main()
        {
            Console.WriteLine("Enter sequence of words: ");
            string line = Console.ReadLine();

            if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
            {
                List<string> words = new List<string>();
                string[] elements = line.Split(' ');
                for (int i = 0; i < elements.Length; i++)
                {
                    words.Add(elements[i]);
                }

                words.Sort();
                Console.WriteLine(string.Join(" ", words));
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
