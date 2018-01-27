using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EventStream.Configuration
{
    public class EventsConfiguration
    {
        public EventsConfiguration(
            Dictionary<string, EventDefinition> allEvents,
            Dictionary<string, IFieldDefinition> ambientFieldDefinitions)
        {
            AllEvents = allEvents;
            AmbientFieldDefinitions = ambientFieldDefinitions;
        }

        public IDictionary<string, EventDefinition> AllEvents { get; }
        public IDictionary<string, IFieldDefinition> AmbientFieldDefinitions { get; }
    }
}