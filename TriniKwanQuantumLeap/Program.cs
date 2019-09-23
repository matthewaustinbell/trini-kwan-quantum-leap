using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TriniKwanQuantumLeap.Data;

namespace TriniKwanQuantumLeap
{
    class Program
    {
        public void intro()
        {

        }
        static void Main(string[] args)
        {
            // Initialize Event Repository and create events
            var eventRepository = new EventRepository();
            var leaperRepository = new LeaperRepository();

            var myLeaper = new Leaper();

            leaperRepository.AddLeaper(myLeaper);

            var event1 = new Event
            {
                Location = "Moon Landing",
                Date = new DateTime(2069, 07, 20),
                Host = "Buzz Aldrin",
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
                Host = "Woodrow Wilson",
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
                Location = "Day Frito-Lay stops making Doritos 3D",
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
                Location = "Chernobyl Disaster",
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

            // Checks if the leaper has leaped yet 
            // If they have and leap again the "would you like to leap" prompt is skipped
            int leapCount = 0;

            void LeapPrompt()
            {
                var budget = new Budget();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine((leapCount == 0 ? " After theorizing that time travel could happen within your own lifetime,\n" +
              " you stepped into the Quantum Leap accelerator, and vanished.\n " +
              "When you awoke you found yourself trapped in the past,\n" +
              " facing a mirror image that was not your own.\n" +
              " Now driven by an unknown force to change history for the better\n" +
              " you are guided by AI (a Hologram that only you can see and hear).\n AI asks in a robotic voice... \n " : null));
                Console.ForegroundColor = ConsoleColor.White;

                int windowWidth = Console.WindowWidth;
                int size = windowWidth;
                Console.WriteLine();
                Console.WriteLine("".PadLeft(size, '=').PadRight(size, '='));
                Console.WriteLine();

                Console.WriteLine("Press enter to continue...");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine((leapCount == 0 ? $"Welcome, traveller. Would you like to take a leap? (y/n)" : null));
                Console.WriteLine();
                string answer = (leapCount == 0 ? Console.ReadLine().ToUpper() : "Y");

                while (true)
                {
                   
                    if (answer == "N")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("FINE! BE BORING!");
                        Console.WriteLine();
                        Environment.Exit(0);
                        break;
                    }

                    if (answer == "Y")
                    {
                        if (myLeaper.Name == null)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("You are very brave to attempt such a feat. What's your name?");
                            Console.WriteLine();
                            var nameResponse = Console.ReadLine();
                            Console.Clear();
                            myLeaper.Name = nameResponse;
                        }

                        // Loops through the dictionary and prints each event, also adds 1 to each Key so 
                        // that they don't start with 0

                        // Filter out current event if user has already made a leap

                        foreach (var singleEvent in eventDictionary)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine();
                            Console.WriteLine($"{singleEvent.Key + 1} Location: {singleEvent.Value.Location}");              
                            Console.WriteLine($"Date: {singleEvent.Value.Date}");                          
                            Console.WriteLine($"Host: {singleEvent.Value.Host}");                         
                            Console.WriteLine($"Made Right? {singleEvent.Value.IsPutRight}");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        // Expects the user to enter the number associated with the event  
                        // and subtracts 1 to match dictionary's index
                        Console.WriteLine();
                        Console.WriteLine($"Please select the leap you would like to complete, {myLeaper.Name}.");
                        Console.WriteLine();
                        int chosenLeapIndex = int.Parse(Console.ReadLine());
                        Console.Clear();
                        var chosenLeap = eventDictionary[chosenLeapIndex - 1];

                        // Returns the number of days between today and the chosen leap
                        var attemptedLeap = eventRepository.DaysBetweenEvents(eventRepository.StartingDate(), chosenLeap.Date);

                        // Uses TimeSpan, that's where .Days comes from 
                        Console.WriteLine();
                        Console.WriteLine($"Days to leap: {Math.Abs(attemptedLeap.Days)}");

                        // Prints cost to leap between two dates
                        Console.WriteLine();
                        Console.WriteLine($"Cost to leap: ${budget.TotalLeapCost(attemptedLeap)}");

                        // Checks budget
                        Console.WriteLine();
                        budget.checkBalance(budget.TotalLeapCost(attemptedLeap), chosenLeap);

                        Console.WriteLine();
                        leaperRepository.TakeTheLeap(chosenLeap, myLeaper);

                        Console.WriteLine();
                        Console.WriteLine($"You are now inhabiting the body of {myLeaper.CurrentEventObj.Host}.");

                        Console.WriteLine();
                        Console.WriteLine("You arrived just in time to make this situation right.");

                        var futureDateToChange = eventRepository.UpdateEvent(chosenLeap.Date);

                        Console.WriteLine();
                        Console.WriteLine($"However, your actions have also changed the {futureDateToChange.Location}.");

                        Console.WriteLine();
                        Console.WriteLine("Take heed. Every action you take throughout time can change the course of history.");

                        break;

                    }
                    Console.WriteLine();
                    Console.WriteLine("Please reply with y or n");
                    answer = Console.ReadLine().ToUpper();
                }
            }

            void Prompter()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("1. Make another leap");
                Console.WriteLine("2. See leap history");
                Console.WriteLine("3. End Journey");
                Console.WriteLine();
                int resp = int.Parse(Console.ReadLine());
                Console.Clear();
                ExecuteProgram(resp);
            }

            void ExecuteProgram(int response)
            {
                    if (response == 1)
                    {
                        LeapPrompt();
                        Prompter();
                    }
                    else if (response == 2)
                    {
                    Console.ForegroundColor = ConsoleColor.Blue;
                        leaperRepository.GetLeapHistory(myLeaper);
                        Prompter();
                    }
                    else if (response == 3)
                    {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Adios!");
                        return;
                    }              
            }

            LeapPrompt();
            leapCount++;

            Console.WriteLine();
            int windowWidth1 = Console.WindowWidth;
            int size1 = windowWidth1;
            Console.WriteLine();
            Console.WriteLine("".PadLeft(size1, '=').PadRight(size1, '='));
            Console.WriteLine();


            Prompter();

        }
    }
}
