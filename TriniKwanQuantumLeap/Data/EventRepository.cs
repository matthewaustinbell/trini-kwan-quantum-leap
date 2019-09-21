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

        public void AddEvent(Event eventToAdd)
        {
            eventToAdd.Id = Guid.NewGuid();

            _events.Add(eventToAdd);
        }

        public DateTime UpdateEvent(Guid currentEvent)
        {
            var dateOfCurrentEvent = _events.First(x => x.Id == currentEvent);

          //  eventToUpdate.IsPutRight = true;

            return dateOfCurrentEvent.Date;

        }

        public List<Event> DistanceBetweenDates(DateTime currentDate)
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

            foreach (var day in futureDays)
            {
                Console.WriteLine(day.Location);
            }

            return futureDays;
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
