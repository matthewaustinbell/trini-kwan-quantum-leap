using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TriniKwanQuantumLeap.Data;

namespace TriniKwanQuantumLeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventRepository = new EventRepository();

            var event1 = new Event
            {
                Location = "Nashville",
                Date = new DateTime(2019, 09, 19),
                Host = "Your Mom",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event1);

            var event2 = new Event
            {
                Location = "Memphis",
                Date = new DateTime(1990, 09, 19),
                Host = "Larry King",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event2);

            var event3 = new Event
            {
                Location = "Knoxville",
                Date = new DateTime(1800, 09, 15),
                Host = "Oprah Winfrey",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event3);

            var allEvents = eventRepository.GetAllEvents();

            eventRepository.UpdateEvent(event1.Id);

            foreach (var singleEvent in allEvents)
            {
                Console.WriteLine($"Location: {singleEvent.Location}");
                Console.WriteLine($"Date: {singleEvent.Date}");
                Console.WriteLine($"Host: {singleEvent.Host}");
                Console.WriteLine($"Made Right? {singleEvent.IsPutRight}");
                Console.WriteLine();
            }

            var distanceTest = eventRepository.DistanceBetweenDates(event3.Date, event2.Date);

            Console.WriteLine(distanceTest);

        }
    }
}
