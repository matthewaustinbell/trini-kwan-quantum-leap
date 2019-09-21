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
    }

    internal class Leaper
    {
        public string Name { get; set; }
        public List<Event> LeapHistory { get; set; } = new List<Event>();
        public Event CurrentEventObj { get; set; }
    }
}
