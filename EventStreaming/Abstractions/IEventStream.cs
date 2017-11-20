namespace EventStreaming.Abstractions
{
    public interface IEventStream
    {
        /// <summary>
        ///     Adds values from ambient context and passes event to dispatcher/sender
        /// </summary>
        void SendAsync(Event eventToSend);
    }
}