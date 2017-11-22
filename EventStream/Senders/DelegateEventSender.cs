﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventStream.Senders
{
    public class DelegateEventSender : IEventSender
    {
        private readonly Action<Event> _eventSendAction;
        private readonly Task<bool> _completedTask = Task.FromResult(true);

        public DelegateEventSender(Action<Event> eventSendAction)
        {
            _eventSendAction = eventSendAction;
        }
        
        public Task<bool> SendEvents(IReadOnlyList<Event> events)
        {
            foreach (var e in events)
            {
                _eventSendAction(e);
            }

            return _completedTask;
        }
    }
}