using System;
using System.Collections.Generic;
using EventStream.Abstractions;

namespace EventStream.Senders
{
    public class DelegateEventSender : IEventSender
    {
        private readonly Action<IList<Event>, Action<bool>> _eventSendAction;

        public DelegateEventSender(Action<IList<Event>, Action<bool>> eventSendAction)
        {
            _eventSendAction = eventSendAction;
        }

        public void SendEvents(IList<Event> events, Action<bool> callback)
        {
            _eventSendAction(events, callback);
        }
    }
}