using EventStreaming.Configuration;

namespace EventStream.Generator
{
    public partial class EventsGenerator
    {
        private readonly string _className;
        private readonly string _namespace;
        private readonly EventDefinition[] _events;

        public EventsGenerator(
            string className,
            string @namespace,
            EventDefinition[] events)
        {
            _className = className;
            _namespace = @namespace;
            _events = events;
        }
    }
}
