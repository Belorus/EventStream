using System.Collections.Generic;

namespace EventStreaming
{
    public interface IAmbientContext
    {
        object GetValue(string key);

        int UserSeed { get; }
    }
}