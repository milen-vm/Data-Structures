namespace CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    class CalculateSequenceWithQueue
    {
        private const int sequenceMembersCount = 50;
        static void Main()
        {
            Console.Write("Enter start integer: ");
            int startNum = int.Parse(Console.ReadLine());
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(startNum);
            int count = 1;
            PrintSequenceMember(startNum, count);

            while (count < sequenceMembersCount)
            {
                int currentNumber = sequence.Dequeue();

                sequence.Enqueue(currentNumber + 1);
                ++count;
                PrintSequenceMember(currentNumber + 1, count);

                sequence.Enqueue(2 * currentNumber + 1);
                ++count;
                PrintSequenceMember(2 * currentNumber + 1, count);

                sequence.Enqueue(currentNumber + 2);
                ++count;
                PrintSequenceMember(currentNumber + 2, count);
            }
        }

        private static void PrintSequenceMember(int member, int orderNumber)
        {
            if (orderNumber < sequenceMembersCount)
            {
                Console.Write(member + ", ");
            }
            else if (orderNumber == sequenceMembersCount)
            {
                Console.WriteLine(member);
            }
        }
    }
}
