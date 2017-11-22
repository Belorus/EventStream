using System.Collections.Generic;
using System.Linq;

namespace EventStream
{
    public struct Event
    {
        public readonly string Name;

        public Event(
            string name,
            IReadOnlyList<KeyValuePair<string, object>> fields)
        {
            Name = name;
            Fields = fields;
        }

        public readonly IReadOnlyList<KeyValuePair<string, object>> Fields;

        public Event With(IEnumerable<KeyValuePair<string, object>> fields)
        {
            return new Event(Name, Fields.Union(fields).ToArray());
        }
    }
}