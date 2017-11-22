using System;
using System.Collections.Generic;
using System.Threading;

namespace EventStream.Dispatchers
{
    public class BufferingEventDispatcher : IEventDispatcher
    {
        private readonly Queue<Event> _queue = new Queue<Event>();
        private readonly IEventSender _sender;
        private readonly object _syncRoot = new object();
        private Timer _timer;

        public BufferingEventDispatcher(IEventSender sender)
        {
            _sender = sender;
        }

        public TimeSpan FlushDelay { get; set; } = TimeSpan.FromSeconds(10);

        public int MaxQueueSize { get; set; } = 10;

        public void Dispatch(Event eventToSend)
        {
            bool isQueueFull;
            lock (_syncRoot)
            {
                _queue.Enqueue(eventToSend);
                isQueueFull = _queue.Count > MaxQueueSize;
            }

            if (isQueueFull)
                Flush();
            else
                EnsureTimerRuns();
        }

        private void EnsureTimerRuns()
        {
            lock (_syncRoot)
            {
                if (_timer == null)
                {
                    _timer = new Timer(_ => Flush(), null, (int) FlushDelay.TotalMilliseconds, 0);
                }
            }
        }

        private void Flush()
        {
            Event[] array;
            lock (_syncRoot)
            {
                _timer?.Dispose();
                _timer = null;
                
                array = _queue.ToArray();
                _queue.Clear();
            }
            _sender.SendEvents(array);
        }
    }
}