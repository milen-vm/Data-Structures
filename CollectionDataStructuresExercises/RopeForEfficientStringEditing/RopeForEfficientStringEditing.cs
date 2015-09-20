using System;
using Wintellect.PowerCollections;

class RopeForEfficientStringEditing
{
    private static BigList<char> chars = new BigList<char>();

    static void Main()
    {
        string input = Console.ReadLine();
        while (input != string.Empty)
        {
            int separatorIndex = input.IndexOf(' ');
            string command;
            if (separatorIndex < 0)
            {
                command = input;
            }
            else
            {
                command = input.Substring(0, separatorIndex);
            }

            try
            {
                switch (command)
                {
                    case "INSERT":
                        Insert(input.Substring(separatorIndex + 1));
                        break;
                    case "APPEND":
                        Append(input.Substring(separatorIndex + 1));
                        break;
                    case "DELETE":
                        Delete(input.Substring(separatorIndex + 1));
                        break;
                    case "PRINT":
                        Print();
                        break;
                    default:
                        throw new Exception();
                }

                if (command != "PRINT")
                {
                    Console.WriteLine("OK");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR");
            }

            input = Console.ReadLine();
        }
    }

    private static void Print()
    {
        Console.WriteLine(string.Join("", chars));
    }

    private static void Delete(string str)
    {
        var par = str.Split(' ');
        int startIndex = int.Parse(par[0]);
        int count = int.Parse(par[1]);
        chars.RemoveRange(startIndex, count);
    }

    private static void Append(string str)
    {
        var charArr = str.ToCharArray();
        chars.AddRange(charArr);
    }

    private static void Insert(string str)
    {
        var charArr = str.ToCharArray();
        chars.AddRangeToFront(charArr);
    }
}