using System;
using System.Linq;

class CountSymbols
{
    static void Main()
    {
        Console.WriteLine("Enter symbols:");
        string line = Console.ReadLine();
        var symbolsCount = new MyDictonary<char, int>();
        foreach (char ch in line)
        {
            if (!symbolsCount.ContainsKey(ch))
            {
                symbolsCount.Add(ch, 0);
            }

            symbolsCount[ch]++;
        }

        symbolsCount.OrderBy(item => item.Key);

        var keys = symbolsCount.Keys.OrderBy(value => value);
        foreach (var key in keys)
        {
            Console.WriteLine("{0}: {1} time/s", key, symbolsCount[key]);
        }
    }
}
