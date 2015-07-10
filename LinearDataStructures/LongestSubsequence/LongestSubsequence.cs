namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestSubsequence
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

                int maxRepeatNumber = numbers[0];
                int maxCount = 1;
                int currentCount = 1;
                for (int i = 1; i < numbers.Count; i++)
                {
                    int currNum = numbers[i];
                    int prevNum = numbers[i - 1];
                    if (prevNum == currNum)
                    {
                        ++currentCount;
                        if (i == numbers.Count - 1)
                        {
                            if (currentCount > maxCount)
                            {
                                maxCount = currentCount;
                                maxRepeatNumber = currNum;
                            }
                        }
                    }
                    else
                    {
                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            maxRepeatNumber = prevNum;
                        }

                        currentCount = 1;
                    }
                }

                List<int> sequence = Enumerable.Repeat(maxRepeatNumber, maxCount).ToList();
                Console.WriteLine(string.Join(" ", sequence));
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
