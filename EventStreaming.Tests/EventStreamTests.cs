using System.Collections.Generic;
using System.Linq;
using EventStreaming.Configuration;
using Moq;
using Xunit;

namespace EventStreaming.Tests
{
    public class EventStreamTests
    {
        [Fact]
        public void Ambient_Fields_Are_Added()
        {
            var config = new FullEventsConfiguration(
                new Dictionary<string, EventDefinition>{ {"TEST", new EventDefinition(new Dictionary<string, IFieldDefinition>(), 100, "TEST")}},
                new Dictionary<string, IFieldDefinition>());

            var ambientContext = new Mock<IAmbientContext>();
            ambientContext.Setup(x => x.GetAmbientData())
                          .Returns(new[]
                          {
                              new KeyValuePair<string, object>("A1", "V1"),
                              new KeyValuePair<string, object>("A2", "V2")
                          });

            var dispatcherMock = new Mock<IEventDispatcher>();
            
            var sut = new EventStream(ambientContext.Object, dispatcherMock.Object, config);

            sut.SendAsync(new Event("TEST", new KeyValuePair<string, object>[0]));

            dispatcherMock.Verify(x => x.Dispatch(It.Is<Event>(e =>
                e.Fields.Length == 2 &&
                e.Fields[0].Key == "A1" && e.Fields[0].Value == "V1" &&
                e.Fields[1].Key == "A2" && e.Fields[1].Value == "V2"
            )));
        }
    }
}
