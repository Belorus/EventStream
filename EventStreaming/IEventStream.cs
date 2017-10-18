namespace EventStreaming
{
    public interface IEventStream
    {
        void SendAsync(Event eventToSend);
    }
}