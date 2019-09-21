using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TriniKwanQuantumLeap.Data
{
    class EventRepository
    {
        static List<Event> _events = new List<Event>();

        public List<Event> GetAllEvents()
        {
            return _events;
        }

        public Event GetSingleEvent(Guid eventId)
        {
            var singleEvent = _events.First(x => x.Id == eventId);

            return singleEvent;
        }

        public DateTime StartingDate()
        {
            var startingPoint = DateTime.Now;
            return startingPoint;
        }

        public void AddEvent(Event eventToAdd)
        {
            eventToAdd.Id = Guid.NewGuid();

            _events.Add(eventToAdd);
        }

        public TimeSpan DaysBetweenEvents(DateTime date1, DateTime date2)
        {
            TimeSpan daysInBetween = date2 - date1;

            return daysInBetween;
        }


        public Event UpdateEvent(DateTime currentDate)
        {
            TimeSpan zero = new TimeSpan(0, 0, 0);

            List<Event> futureDays = new List<Event>();

            foreach (var singleEvent in _events)
            {
                TimeSpan daysInBetween = currentDate - singleEvent.Date;
                if (daysInBetween < zero)
                {
                    futureDays.Add(singleEvent);
                }
            }

            var randomDay = new Random();

            var randomDayIndex = randomDay.Next(futureDays.Count);

            futureDays[randomDayIndex].IsPutRight = true;

            var adjustedDay = futureDays[randomDayIndex];

            return adjustedDay;
        }

    }

    internal class Event
    {
        public Guid Id { get; set; }
        public bool IsPutRight { get; set; }

        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Host { get; set; }

    }
}
