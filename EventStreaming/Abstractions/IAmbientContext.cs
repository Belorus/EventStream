namespace EventStreaming.Abstractions
{
    public interface IAmbientContext
    {
        /// <summary>
        ///     Value in range [0..99] that is used in sampling process.
        ///     Event sampling percent is compared to this value.
        /// </summary>
        int UserSeed { get; }

        object GetValue(string key);
    }
}