using System.Collections.Generic;
using System.IO;
using EventStreaming;
using EventStreaming.Configuration;

namespace EventStream.Console.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigParser(File.OpenRead("config.json")).ReadFullConfig();
            var eventStreaming = new EventStreaming.EventStream(new BufferingEventDispatcher(new HttpSender("http://estream.playtika.com/CL/")){ MaxQueueSize = 0 }, config);

            eventStreaming.QueueSending(GeneratedEvents.LOGGED_IN("123", "155"));

            System.Console.ReadLine();
        }
    }
}
