using System;
using System.Collections.Generic;
using System.Threading;

namespace EventStreaming
{
    public class BufferingEventDispatcher : IEventDispatcher
    {
        private readonly IEventSender _sender;
        
        private readonly Queue<Event> _queue = new Queue<Event>();
        private Timer _timer;

        public BufferingEventDispatcher(
            IEventSender sender)
        {
            _sender = sender;
        }
        
        public TimeSpan FlushDelay { get; set; } = TimeSpan.FromSeconds(10);

        public int MaxQueueSize { get; set; } = 10;
        
        public void Dispatch(Event eventToSend)
        {
            _queue.Enqueue(eventToSend);

            if (_queue.Count > MaxQueueSize)
            {
                Flush();
            }
            else
            {
                EnsureTimerRuns();
            }
        }

        private void EnsureTimerRuns()
        {
            if (_timer == null)
            {
                _timer = new Timer(OnTimer, null, (int)FlushDelay.TotalMilliseconds, 0);
            }
        }

        private void OnTimer(object state)
        {
            _timer?.Dispose();
            _timer = null;
            
            Flush();
        }

        private void Flush()
        {
            _sender.SendEvents(_queue.ToArray());
        }
    }
}