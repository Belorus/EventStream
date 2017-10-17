using System;
using System.Collections.Generic;
using System.Linq;
using EventStreaming.Configuration;

namespace EventStreaming
{
    public class EventStream
    {
        private readonly IAmbientContext _ambientContext;
        private readonly IEventDispatcher _dispatcher;
        private readonly FullEventsConfiguration _configuration;

        public EventStream(
            IAmbientContext ambientContext,
            IEventDispatcher dispatcher,
            FullEventsConfiguration configuration)
        {
            _ambientContext = ambientContext;
            _dispatcher = dispatcher;
            _configuration = configuration;
        }
        
        public void QueueSending(Event eventToSend)
        {
            var richEvent = CreateRichEvent(eventToSend);

            _dispatcher.Dispatch(richEvent);
        }

        public Event CreateRichEvent(Event eventToSend)
        {
            EventDefinition definition;
            if (!_configuration.AllEvents.TryGetValue(eventToSend.Name, out definition))
                throw new ArgumentException($"Unknown event {eventToSend.Name}");

            var additionalFields = Enumerable.Union(
                definition.Fields.Values.OfType<StaticFieldDefinition>()
                    .Select(f => new KeyValuePair<string, object>(f.Name, f.Value)),
                _ambientContext.GetAmbientData());

            return new Event(
                eventToSend.Name,
                Enumerable.Union(additionalFields, eventToSend.Fields).ToArray());
        }
    }
}
