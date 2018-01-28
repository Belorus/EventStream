using System;
using System.Collections.Generic;
using EventStream.Abstractions;
using EventStream.Dispatchers;
using EventStream.Storage;
using Moq;
using Xunit;

namespace EventStream.Tests
{
    public class StoringEventSenderProxyTests
    {
        [Fact]
        public void StoreIsNeverCalledOnSuccessSend()
        {
            var firstEvent = new Event("TEST1", new List<KeyValuePair<string, object>>());

            var senderMock = new Mock<IEventSender>();
            senderMock.Setup(s => s.SendEvents(It.IsAny<IList<Event>>(), It.IsAny<Action<bool>>()))
                .Callback<IList<Event>, Action<bool>>((e, c) => c(true));

            var storageMock = new InMemoryStorage<IList<Event>>();

            var storingEventSenderProxy = new StoringEventSenderProxy(senderMock.Object, storageMock);
            storingEventSenderProxy.SendEvents(new List<Event>() {firstEvent}, isSuccess => { });

            Assert.False(storageMock.HasData);
        }

        [Fact]
        public void StoreIsCalledOnSuccessSend()
        {
            var firstEvent = new Event("TEST1", new List<KeyValuePair<string, object>>());

            var senderMock = new Mock<IEventSender>();
            senderMock.Setup(s => s.SendEvents(It.IsAny<IList<Event>>(), It.IsAny<Action<bool>>()))
                .Callback<IList<Event>, Action<bool>>((e, c) => c(false));

            var storageMock = new InMemoryStorage<IList<Event>>();

            var storingEventSenderProxy = new StoringEventSenderProxy(senderMock.Object, storageMock);
            storingEventSenderProxy.SendEvents(new List<Event>() {firstEvent}, isSuccess => { });

            Assert.True(storageMock.HasData);
        }

        [Fact]
        public void OldEventsAreResentAfterFailure()
        {
            var firstEventGroup = new[] {new Event("TEST1", new List<KeyValuePair<string, object>>())};
            var secondEventGroup = new[] {new Event("TEST2", new List<KeyValuePair<string, object>>())};

            var senderMock = new Mock<IEventSender>();
            var storageMock = new InMemoryStorage<IList<Event>>();

            var storingEventSenderProxy = new StoringEventSenderProxy(senderMock.Object, storageMock);

            senderMock.Setup(s => s.SendEvents(firstEventGroup, It.IsAny<Action<bool>>())).Callback<IList<Event>, Action<bool>>((e, c) => c(false));
            storingEventSenderProxy.SendEvents(firstEventGroup, isSuccess => { Assert.False(isSuccess); });

            var successfullySent = new List<IList<Event>>();
            senderMock.Setup(s => s.SendEvents(It.IsAny<IList<Event>>(), It.IsAny<Action<bool>>()))
                .Callback<IList<Event>, Action<bool>>((e, c) =>
                {
                    successfullySent.Add(e);
                    c(true);
                });

            storingEventSenderProxy.SendEvents(secondEventGroup, isSuccess => { Assert.True(isSuccess); });

            Assert.Contains(firstEventGroup, successfullySent);
            Assert.Contains(secondEventGroup, successfullySent);
            Assert.Equal(2, successfullySent.Count);
        }
    }
}
