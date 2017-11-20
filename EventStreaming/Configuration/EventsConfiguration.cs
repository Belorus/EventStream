using System.Collections.Generic;

namespace EventStreaming.Configuration
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

        public Dictionary<string, EventDefinition> AllEvents { get; }
        public Dictionary<string, IFieldDefinition> AmbientFieldDefinitions { get; }
    }
}