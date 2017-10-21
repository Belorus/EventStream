using System.Collections.Generic;
using System.Linq;

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

        public Event With(IEnumerable<KeyValuePair<string, object>> fields)
        {
            return new Event(Name, Fields.Union(fields).ToArray());
        }
    }
}