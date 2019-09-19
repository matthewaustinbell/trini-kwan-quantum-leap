using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TriniKwanQuantumLeap.Data
{
    class EventRepository
    {
        static List<Event> _events = new List<Event>();
    }

    class Event
    {
        public Guid Id { get; set; }
        public bool IsPutRight { get; set; }

        readonly string _location;
        readonly string _date;
        readonly string _host;

    }
}
