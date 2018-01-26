using System.Collections.Generic;

namespace EventStream
{
    public struct Event
    {
        public readonly string Name;

        public Event(
            string name,
            ICollection<KeyValuePair<string, object>> fields)
        {
            Name = name;
            Fields = fields;
        }

        public readonly ICollection<KeyValuePair<string, object>> Fields;

        public Event With(IEnumerable<KeyValuePair<string, object>> fields)
        {
            var newDictionary = new Dictionary<string, object>(Fields.Count);
            foreach (var kv in Fields)
            {
                newDictionary[kv.Key] = kv.Value;
            }
            
            foreach (var kv in fields)
            {
                newDictionary[kv.Key] = kv.Value;
            }

            return new Event(Name, newDictionary);
        }
        
        public Event With(string key, object value)
        {
            var newDictionary = new Dictionary<string, object>(Fields.Count + 1);
            foreach (var kv in Fields)
            {
                newDictionary[kv.Key] = kv.Value;
            }
            newDictionary[key] = value;
            
            return new Event(Name, newDictionary);
        }
     
    }
}