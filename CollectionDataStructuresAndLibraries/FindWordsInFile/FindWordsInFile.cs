using System;
using System.Collections.Generic;

class FindWordsInFile
{
    static void Main()
    {
        int textLines = int.Parse(Console.ReadLine());
        var dict = new Dictionary<string, int>();
        for (int i = 0; i < textLines; i++)
        {
            string line = Console.ReadLine();
            string[] words = line.Split(new char[] { ' ', ',', '.', '?', '!', ':', '-', ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < words.Length; j++)
            {
                if (!dict.ContainsKey(words[j]))
                {
                    dict[words[j]] = 0;
                }

                ++dict[words[j]];
            }
        }

        int searchCount = int.Parse(Console.ReadLine());
        string[] searchWords = new string[searchCount];
        for (int i = 0; i < searchCount; i++)
        {
            searchWords[i] = Console.ReadLine();
        }

        foreach (var word in searchWords)
        {
            if (dict.ContainsKey(word))
            {
                Console.WriteLine("{0} -> {1}", word, dict[word]);
            }
            else
            {
                Console.WriteLine("{0} -> 0", word);
            }
        }
    }
}
