﻿using System;
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

    }

    internal class Event
    {
        public Guid Id { get; set; }
        public bool IsPutRight { get; set; }

        public string Location { get; set; }
        public string Date { get; set; }
        public string Host { get; set; }

    }
}