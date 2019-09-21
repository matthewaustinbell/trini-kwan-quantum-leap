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

                // Checks budget, commented out temporarily
                //   budget.checkBalance();

                // Prints cost to leap between two dates
                Console.WriteLine($"Cost to leap ${budget.TotalLeapCost(attemptedLeap)}");
                break;
            }


            //Emily's code begins here
            Console.WriteLine("Emily's code");
            Console.WriteLine("Hello Leaper! What's your name?");
            var nameInput = Console.ReadLine();

            Console.WriteLine("Where are you currently located?");
            var locationInput = Console.ReadLine();

            var currentDate = DateTime.Now;
            var currentHost = nameInput;
            var currentLocation = locationInput;
            var IsPutRight = true;
            var randomGuid = Guid.NewGuid();

            // Make the five variables above into an object and assign it as the Leaper's CurrentEventObj

            // add the Leaper to the LeaperRepo

            Console.WriteLine("Welcome, {Leaper.Name}. To which event would you like to travel? " +
                "              Type the Event Id of the Event to which you'd like to travel and press enter.");

            // Loop over all events in our event list and print the following for each:
            // Event Id: {Event.Id}
            // Date: {Event.Date}
            // Location: {Event.Location}
            // Host: {Event.Host}

            // var eventObjectToLeapTo = *find the event Object using the Id they entered above*
            // var activeLeaper = *our current leaper*

            // ----> Commented out so code will compile <----
            //LeaperRepository.AttemptLeap(/*eventObjectToLeapTo, activeLeaper*/);
            // ----> Commented out so code will compile <----

            // The AttemptLeapMethod above will return 'true' if leap can be made or 'false' if more funds are needed
            // If true:
            Console.WriteLine("Congratulations! You made it to {Event.Description} in {Event.Location} on {Event.Date}. " +
                    "Operating as {Event.Host}, you were able to fix this situation and change the course of history.");

                Console.WriteLine("Would you like to leap again? (y/n)");
            // If yes, somehow... start again?

            // If false:
            Console.WriteLine("Enter the amount of money you would like to add to your budget.");

            var amountToAddToBudget = Console.ReadLine();
            // var amountInIntegerForm = function to make their input an integer

            // create a method in the budget class that takes the value and adds it to the budget.




            Console.WriteLine("Matt Gill's code");
            // Matt Gill's code begins here

            var currentDateTest = eventRepository.UpdateEvent(event2.Date);

            Console.WriteLine($"{currentDateTest.Location} has been made right! {currentDateTest.IsPutRight}");

           // var distanceTest = eventRepository.DistanceBetweenDates(event3.Date, event2.Date);

        }
    }
}
