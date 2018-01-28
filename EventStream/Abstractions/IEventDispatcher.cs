namespace EventStream.Abstractions
{
    public interface IEventDispatcher
    {
        void Dispatch(Event eventToDispatch);
    }
}