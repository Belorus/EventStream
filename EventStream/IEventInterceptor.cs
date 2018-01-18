namespace EventStream
{
    public interface IEventInterceptor
    {
        Event Process(Event @event);
    }
}