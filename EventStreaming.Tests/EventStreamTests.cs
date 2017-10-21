using System.Collections.Generic;
using EventStreaming.Configuration;
using Moq;
using Xunit;

namespace EventStreaming.Tests
{
    public class EventStreamTests
    {
        [Fact]
        public void Referenced_Fields_Are_Added()
        {
            var ambientField = new DynamicFieldDefinition("A1", ConfigParser.FieldType.String);
            var config = new FullEventsConfiguration(
                new Dictionary<string, EventDefinition>
                {
                    {
                        "TEST", new EventDefinition(new Dictionary<string, IFieldDefinition>()
                        {
                            {"A1ref", new ReferenceFieldDefinition("A1ref", ambientField)},
                        }, 100, "TEST")
                    }
                },
                new Dictionary<string, IFieldDefinition>{ { ambientField.Name, ambientField } });

            var ambientContext = new Mock<IAmbientContext>();
            ambientContext.Setup(x => x.GetValue("A1")).Returns("V1");
                          
            var dispatcherMock = new Mock<IEventDispatcher>();

            var sut = new EventStream(ambientContext.Object, dispatcherMock.Object, config);

            sut.SendAsync(new Event("TEST", new KeyValuePair<string, object>[0]));

            dispatcherMock.Verify(x => x.Dispatch(It.Is<Event>(e =>
                e.Fields.Length == 1 &&
                e.Fields[0].Key == "A1ref" && e.Fields[0].Value == "V1"
            )));
        }

        [Fact]
        public void Event_Is_Sampled_By_Seed()
        {
            var config = new FullEventsConfiguration(
                new Dictionary<string, EventDefinition>{ {"TEST", new EventDefinition(new Dictionary<string, IFieldDefinition>(), 5, "TEST")}},
                new Dictionary<string, IFieldDefinition>());

            var ambientContext = new Mock<IAmbientContext>();
            var dispatcherMock = new Mock<IEventDispatcher>();
            
            var sut = new EventStream(ambientContext.Object, dispatcherMock.Object, config);

            for (int i = 0; i < 1000; i++) 
            {
                ambientContext.Setup(x => x.UserSeed).Returns(i);
                sut.SendAsync(new Event("TEST", new KeyValuePair<string, object>[0]));
            }
           
            dispatcherMock.Verify(x => x.Dispatch(It.IsAny<Event>()), Times.Exactly(50));
        }
    }
}
