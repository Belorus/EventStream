using System.Collections.Generic;
using System.Threading.Tasks;
using EventStreaming.Abstractions;

namespace EventStreaming.Dispatchers
{
    public class NullEventSender : IEventSender
    {
        private readonly Task<bool> _completedTask = Task.FromResult(true);

        public Task<bool> SendEvents(IReadOnlyList<Event> events)
        {
            return _completedTask;
        }
    }
}