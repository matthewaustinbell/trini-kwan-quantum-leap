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

        public string UpdateEvent(Guid eventId)
        {
            var eventToUpdate = _events.First(x => x.Id == eventId);

            eventToUpdate.IsPutRight = true;

            return eventToUpdate.Location;

        }

        public TimeSpan DistanceBetweenDates(DateTime date1, DateTime date2)
        {
            TimeSpan daysInBetween = date2 - date1;

            return daysInBetween;
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
