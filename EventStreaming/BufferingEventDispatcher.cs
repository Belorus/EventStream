﻿using System;
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
            bool isQueueFull;
            lock (_queue)
            {
                _queue.Enqueue(eventToSend);
                isQueueFull = _queue.Count > MaxQueueSize;
            }

            if (isQueueFull)
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
            Event[] array;
            lock (_queue)
            {
                array = _queue.ToArray();
                _queue.Clear();
            }
            _sender.SendEvents(array);
        }
    }
}