namespace EventStreaming
{
    public interface IEventDispatcher
    {
        void Dispatch(Event eventToSend);
    }
}