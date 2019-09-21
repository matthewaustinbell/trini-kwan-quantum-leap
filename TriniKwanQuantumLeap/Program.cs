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
            // Initialize Event Repository and create events
            var eventRepository = new EventRepository();
            var leaperRepository = new LeaperRepository();

            var myLeaper = new Leaper()
            {
                Name = "Bob",
            };

            leaperRepository.AddLeaper(myLeaper);

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

            var event4 = new Event
            {
                Location = "Future 1",
                Date = new DateTime(2000, 09, 15),
                Host = "Oprah Winfrey",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event4);
            var event5 = new Event
            {
                Location = "Future 2",
                Date = new DateTime(2010, 09, 15),
                Host = "Oprah Winfrey",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event5);
            var event6 = new Event
            {
                Location = "Future 3",
                Date = new DateTime(2020, 09, 15),
                Host = "Oprah Winfrey",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event6);

            // Creates a Dictionary and adds each event to it
            Dictionary<int, Event> eventDictionary = new Dictionary<int, Event>();
            var allEvents = eventRepository.GetAllEvents();
            for (var i = 0; i < allEvents.Count; i++)
            {
                eventDictionary.Add(i, eventRepository.GetAllEvents()[i]);
            }

            Console.WriteLine("Mark's code");
            // mark's code begin here
            Console.WriteLine("HELLO THERE! WOULD YOU LIKE TO TAKE A LEAP? REPLY WITH Y OR N");
            string answer = Console.ReadLine().ToUpper();
            while (true)
            {
                var budget = new Budget();
                if (answer == "N")
                {
                    Console.WriteLine("FINE! BE BORING!");
                    break;
                }

                if (answer == "Y")
                {
                    // Loops through the dictionary and prints each event, also adds 1 to each Key so 
                    // that they don't start with 0
                    foreach (var singleEvent in eventDictionary)
                    {
                        Console.WriteLine($"{singleEvent.Key + 1} Location: {singleEvent.Value.Location}");
                        Console.WriteLine($"Date: {singleEvent.Value.Date}");
                        Console.WriteLine($"Host: {singleEvent.Value.Host}");
                        Console.WriteLine($"Made Right? {singleEvent.Value.IsPutRight}");
                        Console.WriteLine();
                    }
                    // Expects the user to enter the number associated with the event  
                    // and subtracts 1 to match dictionary's index
                    Console.WriteLine("Please select the leap you would like to complete");
                    int chosenLeapIndex = int.Parse(Console.ReadLine());
                    var chosenLeap = eventDictionary[chosenLeapIndex - 1];

                    // Returns the number of days between today and the chosen leap
                    var attemptedLeap = eventRepository.DaysBetweenEvents(eventRepository.StartingDate(), chosenLeap.Date);

                    // Uses TimeSpan, that's where .Days comes from 
                    Console.WriteLine($"Days to leap {Math.Abs(attemptedLeap.Days)}");

                    // Prints cost to leap between two dates
                    Console.WriteLine($"Cost to leap ${budget.TotalLeapCost(attemptedLeap)}");

                // Checks budget
                budget.checkBalance(budget.TotalLeapCost(attemptedLeap), chosenLeap);

                leaperRepository.TakeTheLeap(chosenLeap, myLeaper);

                Console.WriteLine($"You've taken the leap and your host is {myLeaper.CurrentEventObj.Host}");

                break;

                }
                Console.WriteLine("Please reply with y or n");
                answer = Console.ReadLine().ToUpper();
            }


            Console.WriteLine("Matt Gill's code");
            // Matt Gill's code begins here

            foreach (var singleEvent in allEvents)
            {
                Console.WriteLine($"Location: {singleEvent.Location}");
                Console.WriteLine($"Date: {singleEvent.Date}");
                Console.WriteLine($"Host: {singleEvent.Host}");
                Console.WriteLine($"Made Right? {singleEvent.IsPutRight}");
                Console.WriteLine();
            }
            var currentDateTest = eventRepository.UpdateEvent(event2.Date);

            Console.WriteLine($"{currentDateTest.Location} has been made right! {currentDateTest.IsPutRight}");

            //Console.WriteLine(distanceTest);
           // var distanceTest = eventRepository.DistanceBetweenDates(event3.Date, event2.Date);

        }
    }
}
