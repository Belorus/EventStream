namespace EventStream.Console.Sample
{
    internal class ReplaceGroupInDevBuildInterceptor : IEventInterceptor
    {
        public Event Process(Event @event)
        {
#if DEBUG
            return @event.With("event_group", "BBNC_CLIENT_INSTRUMENTATION_TEST");
#endif
            return @event;
        }
    }
}