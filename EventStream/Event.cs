using System.Collections.Generic;
using System.Linq;

namespace EventStream
{
    public struct Event
    {
        public readonly string Name;

        public Event(
            string name,
            IReadOnlyCollection<KeyValuePair<string, object>> fields)
        {
            Name = name;
            Fields = fields;
        }

        public readonly IReadOnlyCollection<KeyValuePair<string, object>> Fields;

        public Event With(IEnumerable<KeyValuePair<string, object>> fields)
        {
            var newDictionary = Fields.ToDictionary(kv => kv.Key, kv => kv.Value);
            foreach (var kv in fields)
            {
                newDictionary[kv.Key] = kv.Value;
            }

            return new Event(Name, newDictionary);
        }
        
        public Event With(string key, object value)
        {
            var newDictionary = Fields.ToDictionary(kv => kv.Key, kv => kv.Value);
            newDictionary[key] = value;
            
            return new Event(Name, newDictionary);
        }
     
    }
}