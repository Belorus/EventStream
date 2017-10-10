using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace EventStreaming.Tests
{
    public class EventStreamTests
    {
        [Fact]
        public void Foo()
        {
            var dispatcherMock = new Mock<IEventDispatcher>();
            var sut = new EventStream(Mock.Of<IAmbientContext>(), );
        }
    }
}
