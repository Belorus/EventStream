using System.Collections.Generic;

namespace EventStreaming
{
    public interface IAmbientContext
    {
        IEnumerable<KeyValuePair<string, object>> GetAmbientData();
    }
}