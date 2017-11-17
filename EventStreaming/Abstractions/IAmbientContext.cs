namespace EventStreaming.Abstractions
{
    public interface IAmbientContext
    {
        object GetValue(string key);

        int UserSeed { get; }
    }
}