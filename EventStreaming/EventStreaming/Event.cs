using System.Collections.Generic;

namespace EventStreaming
{
    public class Event
    {
        public readonly string Name;

        public Event(
            string name,
            KeyValuePair<string, object>[] fields)
        {
            Name = name;
            Fields = fields;
        }

        public readonly KeyValuePair<string, object>[] Fields;
    }
}