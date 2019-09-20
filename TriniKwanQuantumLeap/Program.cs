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

          
           
            //Emily's code begins here
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

            LeaperRepository.AttemptLeap(/*eventObjectToLeapTo, activeLeaper*/);

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

                       
          
          
          
            // Matt Gill's code begins here
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
