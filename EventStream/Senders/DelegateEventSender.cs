using System;
using System.Collections.Generic;

namespace EventStream.Senders
{
    public class DelegateEventSender : IEventSender
    {
        private readonly Action<Event> _eventSendAction;

        public DelegateEventSender(Action<Event> eventSendAction)
        {
            _eventSendAction = eventSendAction;
        }
        
        public void SendEvents(IList<Event> events)
        {
            foreach (var e in events)
            {
                _eventSendAction(e);
            }
        }
    }
}