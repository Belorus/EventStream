namespace EventStreaming
{
    public class NullEventStream : IEventStream
    {
        public void SendAsync(Event eventToSend)
        {
        }
    }
}