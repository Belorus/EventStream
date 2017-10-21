using System.Collections.Generic;

namespace EventStreaming.Configuration
{
    public class EventsConfiguration
    {
        public Dictionary<string, EventDefinition> AllEvents { get; }
        public Dictionary<string, IFieldDefinition> AmbientFieldDefinitions { get; }

        public EventsConfiguration(
            Dictionary<string, EventDefinition> allEvents,
            Dictionary<string, IFieldDefinition> ambientFieldDefinitions)
        {
            AllEvents = allEvents;
            AmbientFieldDefinitions = ambientFieldDefinitions;
        }
    }
}