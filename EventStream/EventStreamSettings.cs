namespace EventStream
{
    public class EventStreamSettings
    {
        /// <summary>
        ///     If set to <c>false</c> events are not passed to <c>IEventDispatcher</c> / <c>IEventSender</c>
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        ///     If set to <c>false</c> percent value is ignored and all events are passed to <c>IEventDispatcher</c> /
        ///     <c>IEventSender</c>
        ///     By default is <c>true</c>
        /// </summary>
        public bool IsSamplingEnabled { get; set; } = true;
    }
}