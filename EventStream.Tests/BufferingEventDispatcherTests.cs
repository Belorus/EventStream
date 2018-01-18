using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStream.Dispatchers;
using Moq;
using Xunit;

namespace EventStream.Tests
{
    public class BufferingEventDispatcherTests
    {
        [Fact]
        public async Task Event_Is_Sent_When_FlushDelay_Expires()
        {
            var sender = new Mock<IEventSender>();
            var eventToSend = new Event("TEST", new Dictionary<string, object>());

            var sut = new BufferingEventDispatcher(sender.Object)
            {
                MaxQueueSize = 1000,
                FlushDelay = TimeSpan.FromSeconds(1)
            };

            sut.Dispatch(eventToSend);

            sender.Verify(x => x.SendEvents(It.Is<Event[]>(array => array.Contains(eventToSend))), Times.Never);

            await Task.Delay(sut.FlushDelay);

            sender.Verify(x => x.SendEvents(It.Is<Event[]>(array => array.Contains(eventToSend))), Times.Once);
        }

        [Fact]
        public void Event_Is_Sent_When_Q_Is_Full()
        {
            var sender = new Mock<IEventSender>();
            var eventToSend = new Event("TEST", new Dictionary<string, object>());

            var sut = new BufferingEventDispatcher(sender.Object)
            {
                MaxQueueSize = 5,
                FlushDelay = TimeSpan.FromDays(1)
            };

            sut.Dispatch(eventToSend);
            sut.Dispatch(eventToSend);
            sut.Dispatch(eventToSend);
            sut.Dispatch(eventToSend);
            sut.Dispatch(eventToSend);

            sender.Verify(x => x.SendEvents(It.Is<Event[]>(array => array.Contains(eventToSend))), Times.Never);

            sut.Dispatch(eventToSend);

            sender.Verify(x => x.SendEvents(It.Is<Event[]>(array => array.Contains(eventToSend))), Times.Once);
        }
    }
}