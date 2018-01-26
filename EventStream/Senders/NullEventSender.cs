
using System.Collections.Generic;

namespace EventStream.Senders
{
    public class NullEventSender : IEventSender
    {
        public void SendEvents(IList<Event> events)
        {
        }
    }
}