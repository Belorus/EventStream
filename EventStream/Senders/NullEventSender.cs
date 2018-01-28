using System;
using System.Collections.Generic;
using EventStream.Abstractions;

namespace EventStream.Senders
{
    public class NullEventSender : IEventSender
    {
        public void SendEvents(IList<Event> eventsToSend, Action<bool> callback)
        {
            callback(true);
        }
    }
}