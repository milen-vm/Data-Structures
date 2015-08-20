using System;
using System.Collections.Generic;

class Phonebook
{
    private const string SearchCommand = "search";

    static void Main()
    {
        Console.WriteLine("Enter name and phone separated by dash or 'search' command:");
        string input = Console.ReadLine();
        var phonebook = new MyDictonary<string, string>();
        while (input != SearchCommand)
        {
            var elements = input.Split('-');
            try
            {
                phonebook.Add(elements[0], elements[1]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid input: " + input);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            input = Console.ReadLine();
        }

        input = Console.ReadLine();
        while(input != string.Empty)
        {
            string number = null;
            try
            {
                number = phonebook.Get(input);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Contact {0} does not exist.", input);
            }

            if (number != null)
            {
                Console.WriteLine("{0} -> {1}", input, number);
            }

            input = Console.ReadLine();
        }
    }
}