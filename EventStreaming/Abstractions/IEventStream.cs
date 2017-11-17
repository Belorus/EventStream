namespace EventStreaming.Abstractions
{
    public interface IEventStream
    {
        void SendAsync(Event eventToSend);
    }
}