namespace EventStream
{
    public interface IEventDispatcher
    {
        void Dispatch(Event eventToDispatch);
    }
}