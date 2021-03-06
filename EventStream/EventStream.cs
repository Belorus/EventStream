﻿using System;
using System.Collections.Generic;
using EventStream.Abstractions;
using EventStream.Configuration;

namespace EventStream
{
    public class EventStream : IEventStream
    {
        private readonly IAmbientContext _ambientContext;
        private readonly EventsConfiguration _configuration;
        private readonly IEventDispatcher _dispatcher;
        private readonly EventStreamSettings _settings;

        public EventStream(
            IAmbientContext ambientContext,
            IEventDispatcher dispatcher,
            EventStreamSettings settings,
            EventsConfiguration configuration)
        {
            _ambientContext = ambientContext;
            _dispatcher = dispatcher;
            _settings = settings;
            _configuration = configuration;
        }

        public IEventInterceptor BeforeEnrichInterceptor { get; set; }
        
        public IEventInterceptor BeforeDispatchInterceptor { get; set; }

        /// <summary>
        ///     Adds values from ambient context and passes event to dispatcher/sender
        /// </summary>
        public void SendAsync(Event eventToSend)
        {
            if (IsEligibleForBeingSent(eventToSend))
            {
                var eventCopy = BeforeEnrichInterceptor?.Process(eventToSend) ?? eventToSend;
                eventCopy  = CreateRichEvent(eventCopy);
                eventCopy  = BeforeDispatchInterceptor?.Process(eventCopy ) ?? eventCopy ;
                
                _dispatcher.Dispatch(eventCopy );
            }
        }

        private bool IsEligibleForBeingSent(Event eventToSend)
        {
            if (!_settings.IsEnabled)
                return false;

            if (!_configuration.AllEvents.TryGetValue(eventToSend.Name, out var definition))
                throw new ArgumentException($"Unknown event {eventToSend.Name}");

            if (!_settings.IsSamplingEnabled)
                return true;

            var percent = _ambientContext.UserSeed % 100;

            return percent < definition.Percent;
        }

        // Method is implemented via List<T> without LINQ to achieve better performance and reduce memory traffic 
        private Event CreateRichEvent(Event eventToSend)
        {
            var eventFields = _configuration.AllEvents[eventToSend.Name].Fields.Values;

            var list = new Dictionary<string, object>(eventFields.Count + eventToSend.Fields.Count);

            foreach (var field in eventFields)
            {
                // Take STATIC, DYNAMIC, EVALUATED values from ambient context
                if (field is ReferenceFieldDefinition referenceField)
                {
                    var value = _ambientContext.GetValue(referenceField.ReferencedField.Name);
                    if (value != null)
                        list.Add(referenceField.Name, value);
                }

                // Add STATIC fields from configuration
                if (field is StaticFieldDefinition staticField && staticField.Value != null)
                    list.Add(staticField.Name, staticField.Value);
            }

            // Combine them with DYNAMIC values from event
            foreach (var field in eventToSend.Fields)
            {
                if (field.Value != null)
                {
                    if (list.TryGetValue(field.Key, out object val))
                    {
                        if (!field.Value.Equals(val))
                        {
                            throw new InvalidOperationException($"Trying to replace '{field.Key}': '{val}' -> '{field.Value}'");
                        }
                        else
                        {
                            // Trying to put same same value under same key. Ignoring...
                        }
                    }
                    else
                    {
                        list.Add(field.Key, field.Value);
                    }
                }
            }

            return new Event(eventToSend.Name, list);
        }
    }
}