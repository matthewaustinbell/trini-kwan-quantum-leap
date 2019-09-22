using System;
using System.Collections.Generic;
using System.Text;

namespace TriniKwanQuantumLeap.Data
{
    class LeaperRepository
    {
        static List<Leaper> _leapers = new List<Leaper>();

        public void AddLeaper(Leaper leaperToAdd)
        {
            _leapers.Add(leaperToAdd);
        }

        public void TakeTheLeap(Event eventToJumpTo, Leaper currentLeaper)
        {
            currentLeaper.CurrentEventObj = eventToJumpTo;
            currentLeaper.LeapHistory.Add(eventToJumpTo);
            eventToJumpTo.IsPutRight = true;
        }

        public void GetLeapHistory(Leaper leaper)
        {
            var leapHistory = leaper.LeapHistory;
            int lastEventIndex = leapHistory.Count - 1;

            Console.WriteLine();
            Console.WriteLine($"Leap History for {leaper.Name}:");
            Console.WriteLine();

            for (var i = 0; i < leapHistory.Count; i++)
            {
                if (leapHistory[i] == leapHistory[0])
                {
                    Console.WriteLine("First Event Visited...");
                    Console.WriteLine();
                }
                if (i == lastEventIndex && i != 0)
                {
                    Console.WriteLine("Most Recent Visit...");
                    Console.WriteLine();
                }
                Console.WriteLine($"Location: {leapHistory[i].Location}");
                Console.WriteLine($"Event Date: {leapHistory[i].Date}");
                Console.WriteLine($"Hosted By: {leapHistory[i].Host}");
                Console.WriteLine();
            }
        }
    }

    internal class Leaper
    {
        public string Name { get; set; }
        public List<Event> LeapHistory { get; set; } = new List<Event>();
        public Event CurrentEventObj { get; set; }
    }
}
