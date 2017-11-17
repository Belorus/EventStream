using EventStreaming.Abstractions;

namespace EventStreaming
{
    /// <summary>
    /// Null implementation does nothing. Event are not sent.
    /// </summary>
    public class NullEventStream : IEventStream
    {
        public void SendAsync(Event eventToSend)
        {
        }
    }
}