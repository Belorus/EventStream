using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EventStream.Tests
{
    public class EventTests
    {
        [Fact]
        public void With()
        {
            var evnt = new Event("TEST", new Dictionary<string, object>()
            {
                {"First", 1001},
                {"Second", 1002}
            });

            var modifiedEvent = evnt.With("First", 0).With("Second", 1).With("Third", 2);

            Assert.Equal(0, modifiedEvent.Fields.Single(x => x.Key == "First").Value);
            Assert.Equal(1, modifiedEvent.Fields.Single(x => x.Key == "Second").Value);
            Assert.Equal(2, modifiedEvent.Fields.Single(x => x.Key == "Third").Value);
        }
        
        [Fact]
        public void WithEnumerable()
        {
            var evnt = new Event("TEST", new Dictionary<string, object>()
            {
                {"First", 1001},
                {"Second", 1002}
            });

            var modifiedEvent = evnt.With(new Dictionary<string, object>() {{"First", 0}, {"Second", 1}, {"Third", 2}});

            Assert.Equal(0, modifiedEvent.Fields.Single(x => x.Key == "First").Value);
            Assert.Equal(1, modifiedEvent.Fields.Single(x => x.Key == "Second").Value);
            Assert.Equal(2, modifiedEvent.Fields.Single(x => x.Key == "Third").Value);
        }
    }
}