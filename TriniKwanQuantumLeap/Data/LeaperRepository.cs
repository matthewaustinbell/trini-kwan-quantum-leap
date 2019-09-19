using System;
using System.Collections.Generic;
using System.Text;

namespace TriniKwanQuantumLeap.Data
{
    class LeaperRepository
    {
        List<Leaper> _leapers = new List<Leaper>()
        {

        };

        public List<Leaper> GetAll()
        {
            return _leapers;
        }

        public bool AttemptLeap(object Event, Leaper currentLeaper)
        {
            // use method in budget class that checks to see if there's enough money to make the leap
            // IF enough money (true) -> 
                // 1. Add event id to Leaper's LeapHistory list
                // 2. Update the CurrentEventObj associated with the leaper to the Event to which they're travelling
                // 3. Change the 'IsPutRight' property of the event to 'true'
                // 4. Execute the ButterflyEffect method in the Event class that changes the 'IsPutRight' property of 
                    // a random future event to 'false'
                // 5. Deduct the amount of the trip from the Budget
                // 6. Return 'true'
            // If NOT enough money (false) ->
                // 1. Display message stating amount of money that needs to be added in order to make the trip.
                // 2. Return 'false'
        }
    }

    internal class Leaper
    {
        public string Name { get; }
        public List<Guid> LeapHistory { get; set; }
        public object CurrentEventObj { get; set; }
    }
}
