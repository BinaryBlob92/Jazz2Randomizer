using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;

namespace Jazz2Randomizer
{
    [DataContract]
    public class LevelSettings
    {
        [DataMember(Order = 0)]
        public string LevelFilename { get; set; }
        [DataMember(Order = 1)]
        public bool Jazz { get; set; }
        [DataMember(Order = 2)]
        public bool Spaz { get; set; }
        [DataMember(Order = 3)]
        public bool Lori { get; set; }
        [DataMember(Order = 4)]
        public bool Frog { get; set; }
        [DataMember(Order = 5)]
        public bool Bird { get; set; }
        [DataMember(Order = 6)]
        public bool RandomizeColors { get; set; }
        [DataMember(Order = 7)]
        public List<EventGroup> EventGroups { get; set; }

        private int character;
        private int[] events;
        private int[] bitShifts;

        public LevelSettings()
        {
            Jazz = true;
            Spaz = true;
            Lori = true;
            EventGroups = new List<EventGroup>();
        }

        public void Reset()
        {
            events = null;
            bitShifts = null;
        }

        public void OnLoadLevel(Jazz2 jazz2, Random rng)
        {
            jazz2.Read(jazz2.Address + 0x1191D4, out IntPtr eventsPointer);
            jazz2.Read(eventsPointer, out eventsPointer);

            if (events == null)
            {
                var characterCount = 0;
                var characters = new int[5];
                if (Jazz) characters[characterCount++] = 55;
                if (Spaz) characters[characterCount++] = 89;
                if (Lori) characters[characterCount++] = 61;
                if (Frog) characters[characterCount++] = 47;
                if (Bird) characters[characterCount++] = 8;
                character = characters[rng.Next(characterCount)];

                jazz2.Read(jazz2.Address + 0x10F14C, out int width);
                jazz2.Read(jazz2.Address + 0x1191AC, out int height);

                events = new int[width * height];
                jazz2.Read(eventsPointer, events);

                var eventLookups = new Dictionary<int, int>();
                for (int i = 0; i < events.Length; i++)
                {
                    var eventId = events[i] & 0xFF;
                    var eventGroup = EventGroups.FirstOrDefault(x => x.EventsFrom.Any(y => y.EventId == eventId));
                    if (eventGroup != null)
                    {
                        if (eventGroup.RandomizeIndividually)
                        {
                            events[i] = eventGroup.EventsTo[rng.Next(eventGroup.EventsTo.Count)].EventId;
                        }
                        else
                        {
                            if (!eventLookups.TryGetValue(eventId, out int newEventId))
                            {
                                newEventId = eventGroup.EventsTo[rng.Next(eventGroup.EventsTo.Count)].EventId;
                                eventLookups[eventId] = newEventId;
                            }
                            events[i] = newEventId;
                        }
                    }
                }
            }

            jazz2.Write(eventsPointer, events);
            jazz2.Write(jazz2.Address + 0x1C89E0, character);
            //jazz2.Write(jazz2.Address + 0x14D613, song, 32);
        }

        public void OnLoadTilset(Jazz2 jazz2, Random rng)
        {
            if (RandomizeColors)
            {
                if (bitShifts == null)
                {
                    bitShifts = Enumerable.Range(0, 3)
                        .Select(x => 8 * x)
                        .OrderBy(x => rng.Next())
                        .ToArray();
                }

                int[] colors = new int[256];
                jazz2.Read(jazz2.Address + 0x1607A0, colors);
                for (int i = 0; i < colors.Length; i++)
                {
                    var r = colors[i] & 0xFF;
                    var g = (colors[i] >> 8) & 0xFF;
                    var b = (colors[i] >> 16) & 0xFF;
                    colors[i] = r << bitShifts[0] | g << bitShifts[1] | b << bitShifts[2];
                }
                jazz2.Write(jazz2.Address + 0x1607A0, colors);
            }
        }
    }
}
