using System;
using System.Globalization;
using System.Threading;

using Wintellect.PowerCollections;


class EventsInGivenDateRange
{
    private const string DateTimeFormat = "d-MMM-yyyy HH:mm";

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var events = new OrderedMultiDictionary<DateTime, string>(true);
        int eventsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < eventsCount; i++)
        {
            string eventEntry = Console.ReadLine();
            var eventTokens = eventEntry.Split('|');
            string eventName = eventTokens[0].Trim();
            DateTime eventDate = DateTime.Parse(eventTokens[1].Trim());
            events.Add(eventDate, eventName);
        }

        int seratchCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < seratchCount; i++)
        {
            string dateEntry = Console.ReadLine();
            var dateTokens = dateEntry.Split('|');
            DateTime startDate = DateTime.Parse(dateTokens[0].Trim());
            DateTime endDate = DateTime.Parse(dateTokens[1].Trim());
            var eventsInRange = events.Range(startDate, true, endDate, true);

            Console.WriteLine("\n\rResult:" + eventsInRange);
            PrintEvents(eventsInRange);
            Console.WriteLine();
        }
    }

    private static void PrintEvents(OrderedMultiDictionary<DateTime, string>.View eventsInRange)
    {
        foreach (var eventItem in eventsInRange)
        {
            foreach (var eventName in eventItem.Value)
            {
                Console.WriteLine("{0} | {1}", eventName, eventItem.Key.ToString(DateTimeFormat));
            }
        }
    }
}
