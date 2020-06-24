using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Jazz2Randomizer
{
    [DataContract(IsReference = true)]
    public class EventGroup
    {
        [DataMember(Order = 0)]
        public string Name { get; set; }
        [DataMember(Order = 1)]
        public bool RandomizeIndividually { get; set; }
        [DataMember(Order = 2)]
        public List<EventInfo> EventsFrom { get; set; }
        [DataMember(Order = 3)]
        public List<EventInfo> EventsTo { get; set; }

        public EventGroup()
        {
            EventsFrom = new List<EventInfo>();
            EventsTo = new List<EventInfo>();
        }

        public bool ContainsEventFrom(int eventId) => EventsFrom.Any(x => x.EventId == eventId);
    }
}
