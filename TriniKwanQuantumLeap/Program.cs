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
                Location = "The Moon Landing",
                Date = new DateTime(2069, 07, 20),
                Host = "That guy who had to stay in orbit",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event1);

            var event2 = new Event
            {
                Location = "Assassination of Franz Ferdinand",
                Date = new DateTime(1914, 06, 28),
                Host = "Gavrilo Princip",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event2);

            var event3 = new Event
            {
                Location = "Attack on Pearl Harbor",
                Date = new DateTime(1941, 12, 7),
                Host = "Franklin D. Roosevelt",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event3);

            var event4 = new Event
            {
                Location = "Assassination of J.F.K.",
                Date = new DateTime(1967, 08, 20),
                Host = "Jackie Onassis Kennedy",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event4);

            var event5 = new Event
            {
                Location = "Signing of the Treaty of Versailles",
                Date = new DateTime(1919, 06, 28),
                Host = "Mookie Betts",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event5);

            var event6 = new Event
            {
                Location = "Bombing of Hiroshima",
                Date = new DateTime(1945, 08, 06),
                Host = "Major General Curtis Lemay",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event6);

            var event7 = new Event
            {
                Location = "Boston Tea Party",
                Date = new DateTime(1773, 12, 16),
                Host = "Samuel Adams",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event7);

            var event8 = new Event
            {
                Location = "Frito-Lay stops making Doritos 3D",
                Date = new DateTime(2092, 02, 16),
                Host = "Someone who really freakin' loves Doritos 3D",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event8);

            var event9 = new Event
            {
                Location = "Fall of the Berlin Wall",
                Date = new DateTime(1989, 11, 09),
                Host = "Mikhail Gorbachev",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event9);

            var event10 = new Event
            {
                Location = "THe Chernobyl Disaster",
                Date = new DateTime(1986, 04, 26),
                Host = "Anatoly Dyatlov",
                IsPutRight = false,
            };
            eventRepository.AddEvent(event10);



            // Creates a Dictionary and adds each event to it
            Dictionary<int, Event> eventDictionary = new Dictionary<int, Event>();
            var allEvents = eventRepository.GetAllEvents();
            for (var i = 0; i < allEvents.Count; i++)
            {
                eventDictionary.Add(i, eventRepository.GetAllEvents()[i]);
            }


            // mark's code begin here
            Console.WriteLine(" After theorizing that time travel could happen within your own lifetime,\n" +
                              " you stepped into the quantum Leap accelerator, and vanished.\n " +
                              "When you awoke you found yourself trapped in he past,\n" +
                              " facing a mirror image that was not your own.\n" +
                              " Now driven by an unknown force to change history for the better\n" +
                              " you are guided by AI (a Hologram that only you can see and hear).\n AI asks in a robotic voice... \n ");
            Console.WriteLine("HELLO THERE! WOULD YOU LIKE TO TAKE A LEAP? REPLY WITH Y OR N\n");
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


                var futureDateToChange = eventRepository.UpdateEvent(chosenLeap.Date);

                Console.WriteLine($"{futureDateToChange.Location} has been made right! {futureDateToChange.IsPutRight}");

                    break;

                }
                Console.WriteLine("Please reply with y or n");
                answer = Console.ReadLine().ToUpper();
            }


            Console.WriteLine("Matt Gill's code");
            // Matt Gill's code begins here


            //Console.WriteLine(distanceTest);
           // var distanceTest = eventRepository.DistanceBetweenDates(event3.Date, event2.Date);

        }
    }
}
