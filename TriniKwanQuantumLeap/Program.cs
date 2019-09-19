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
                Date = "09/19/2019",
                Host = "Your Mom",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event1);

            var event2 = new Event
            {
                Location = "Memphis",
                Date = "09/19/1990",
                Host = "Larry King",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event2);

            var event3 = new Event
            {
                Location = "Knoxville",
                Date = "09/19/1800",
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

        }
    }
}
