using System;
using System.Collections.Generic;

namespace EventStream.Abstractions
{
    public interface IEventSender
    {
        void SendEvents(IList<Event> eventsToSend, Action<bool> callback);
    }
}