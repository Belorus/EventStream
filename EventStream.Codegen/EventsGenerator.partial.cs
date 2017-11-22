using System.Collections.Generic;
using EventStream.Configuration;

namespace EventStream.Codegen
{
    public partial class EventsGenerator
    {
        private readonly IReadOnlyDictionary<string, IFieldDefinition> _ambientFieldDefinitions;
        private readonly string _className;
        private readonly EventDefinition[] _events;
        private readonly string _namespace;

        public EventsGenerator(
            string className,
            string @namespace,
            EventDefinition[] events,
            IReadOnlyDictionary<string, IFieldDefinition> ambientFieldDefinitions)
        {
            _className = className;
            _namespace = @namespace;
            _events = events;
            _ambientFieldDefinitions = ambientFieldDefinitions;
        }
    }
}