using System;
using System.Collections.Generic;
using System.Linq;
using EventStream.Dispatchers;
using EventStream.Senders;
using EventStream.Storage;
using Xunit;

namespace EventStream.Tests
{
    public class ResendTest
    {
        [Fact]
        public void AllItemsAreEitherSentOrInStorage()
        {
            var eventsToSend = Enumerable.Range(1, 1000)
                .Select(i => new Event("TEST_" + i, new List<KeyValuePair<string, object>>()))
                .ToList();
            var eventsThatWereSent = new List<Event>();

            var rnd = new Random();
            var sender = new DelegateEventSender((e, callback) =>
            {
                if (rnd.Next(100) < 5) // 5% of events are sent successfuly
                {
                    eventsThatWereSent.AddRange(e);
                    callback(true);
                }
                else
                {
                    callback(false);
                }
            });


            var storage = new InMemoryStorage<IList<Event>>();
            var proxy = new StoringEventSenderProxy(sender, storage);
            var dispatcher = new BufferingEventDispatcher(proxy)
                {
                    MaxQueueSize = 1
                };

            foreach (var e in eventsToSend)
            {
                dispatcher.Dispatch(e);
            }

            Assert.Equal(1000, eventsThatWereSent.Count + storage.Load().Count);
        }
    }
}
