using System;
using System.Collections.Generic;
using System.Linq;
using EventStreaming.Configuration;

namespace EventStreaming
{
    public class EventStream : IEventStream
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
        
        public void SendAsync(Event eventToSend)
        {
            if (IsEligibleForBeingSent(eventToSend))
            {
                var richEvent = CreateRichEvent(eventToSend);

                _dispatcher.Dispatch(richEvent);
            }
        }

        private bool IsEligibleForBeingSent(Event eventToSend)
        {
            if (!_configuration.AllEvents.TryGetValue(eventToSend.Name, out var definition))
                throw new ArgumentException($"Unknown event {eventToSend.Name}");

            int percent = _ambientContext.UserSeed % 100;

            return percent < definition.Percent;
        }

        private Event CreateRichEvent(Event eventToSend)
        {
            var eventFields = _configuration.AllEvents[eventToSend.Name].Fields.Values;

            // Take STATIC, DYNAMIC, EVALUATED values from ambient context
            var referencedValues = eventFields.OfType<ReferenceFieldDefinition>()
                .Select(rf => new KeyValuePair<string,object>(rf.Name, _ambientContext.GetValue(rf.ReferencedField.Name)))
                .Where(f => f.Value != null);

            // Combine them with STATIC and DYNAMIC values from event
            var allFields = eventToSend.Fields
                .Concat(eventFields.OfType<StaticFieldDefinition>().Select(f => new KeyValuePair<string, object>(f.Name, f.Value)))
                .Concat(referencedValues)
                .ToArray();

            return new Event(eventToSend.Name, allFields);
        }
    }
}
