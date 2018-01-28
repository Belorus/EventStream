using System;
using System.Collections.Generic;
using EventStream.Abstractions;

namespace EventStream.Storage
{
    public class StoringEventSenderProxy : IEventSender
    {
        private readonly IEventSender _eventSender;
        private readonly IStorage<IList<Event>> _storage;

        public StoringEventSenderProxy(
            IEventSender eventSender,
            IStorage<IList<Event>> storage)
        {
            _eventSender = eventSender;
            _storage = storage;
        }

        public void SendEvents(IList<Event> eventsToSend, Action<bool> callback)
        {
            if (_storage.HasData)
            {
                SendOldEvents();
            }

            _eventSender.SendEvents(eventsToSend, isSuccess =>
            {
                if (isSuccess)
                {
                    callback(true);
                }
                else
                {
                    _storage.Store(eventsToSend);
                    callback(false);
                }
            });
        }

        private void SendOldEvents()
        {
            Dictionary<string, IList<Event>> unsentEvents = _storage.Load();
            foreach (var kv in unsentEvents)
            {
                _eventSender.SendEvents(kv.Value, isSuccess =>
                {
                    if (isSuccess)
                    {
                        _storage.Remove(kv.Key);
                    }
                });
            }
        }
    }
}