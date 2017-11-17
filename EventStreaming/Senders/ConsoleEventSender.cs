using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStreaming.Abstractions;

namespace EventStreaming.Dispatchers
{
    public class ConsoleEventSender : IEventSender
    {
        private readonly Task<bool> _completedTask = Task.FromResult(true);

        public Task<bool> SendEvents(IReadOnlyList<Event> events)
        {
            foreach (var e in events)
            {
                Console.WriteLine($"{e.Name}: {e.Fields.Select(f => string.Format($"{f.Key}={f.Value}"))}");
            }

            return _completedTask;
        }
    }
}