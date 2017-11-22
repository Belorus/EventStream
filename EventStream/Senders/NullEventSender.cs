using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventStream.Senders
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