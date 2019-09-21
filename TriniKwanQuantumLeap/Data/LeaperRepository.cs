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
            for (var i = 0; i < leapHistory.Count; i++)
            {
                if (leapHistory[i] == leapHistory[0])
                {
                    Console.WriteLine("First Event Visited");
                }
                Console.WriteLine(leapHistory[i].Location);
                Console.WriteLine(leapHistory[i].Date);
                Console.WriteLine(leapHistory[i].Host);

                if (i == lastEventIndex)
                {
                    Console.WriteLine("Most Recent Visit");
                }
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
