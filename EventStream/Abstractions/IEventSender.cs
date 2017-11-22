using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventStream.Abstractions
{
    public interface IEventSender
    {
        Task<bool> SendEvents(IReadOnlyList<Event> eventsToSend);
    }
}