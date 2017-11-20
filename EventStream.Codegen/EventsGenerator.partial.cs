using System.Collections.Generic;
using EventStreaming.Configuration;

namespace EventStream.Generator
{
    public partial class EventsGenerator
    {
        private readonly Dictionary<string, IFieldDefinition> _ambientFieldDefinitions;
        private readonly string _className;
        private readonly EventDefinition[] _events;
        private readonly string _namespace;

        public EventsGenerator(
            string className,
            string @namespace,
            EventDefinition[] events,
            Dictionary<string, IFieldDefinition> ambientFieldDefinitions)
        {
            _className = className;
            _namespace = @namespace;
            _events = events;
            _ambientFieldDefinitions = ambientFieldDefinitions;
        }
    }
}