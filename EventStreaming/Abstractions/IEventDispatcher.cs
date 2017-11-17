namespace EventStreaming.Abstractions
{
    public interface IEventDispatcher
    {
        void Dispatch(Event eventToDispatch);
    }
}