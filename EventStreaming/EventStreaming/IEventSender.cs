using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventStreaming
{
    public interface IEventSender
    {
        Task<bool> SendEvents(Event[] events);
    }
}
