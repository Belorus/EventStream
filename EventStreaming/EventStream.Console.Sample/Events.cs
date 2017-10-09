











using System.Collections.Generic;
using EventStreaming;

namespace EventStream.Console.Sample
{
    public static partial class GeneratedEvents
    {

        public static Event LOGGED_IN(string machineId, string spinsSelected)
        {
            var e = new Event("LOGGED_IN",
			new[]
            {

                new KeyValuePair<string, object>("machine_id", machineId),

                new KeyValuePair<string, object>("spins_selected", spinsSelected),


                new KeyValuePair<string, object>("event_type", "LOGGED_IN"),

                new KeyValuePair<string, object>("event_sub_group", "AUTH"),

                new KeyValuePair<string, object>("event_group", "CLIENT_INSTRUMENTATION"),

            });

            return e;
        }
    }
}