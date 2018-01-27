using System.Collections.Generic;

namespace EventStream
{
    public interface IEventSender
    {
        void SendEvents(IList<Event> eventsToSend);
    }
}