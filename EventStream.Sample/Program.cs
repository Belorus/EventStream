using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BB;
using EventStreaming;
using EventStreaming.Configuration;

namespace EventStream.Console.Sample
{
    class NullEventSender : IEventSender
    {
        public Task<bool> SendEvents(Event[] events)
        {
            return Task.FromResult(true);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigParser(File.OpenRead("config.json")).ReadFullConfig();
            var context = new AmbientContext();
            var eventStreaming = new EventStreaming.EventStream(
                context, 
                new BufferingEventDispatcher(new NullEventSender()){ MaxQueueSize = 10 },
                new EventStreamSettings(),
                config);

            context.SetAppVersion("2.55");
            context.SetOsName("Windows");
            context.SetPlatformType("Windows");
            context.SetUserId("123");
            context.SetSessionId("1234");
            context.SetTimestampFunc(() => DateTime.Now.Millisecond);

            Thread.Sleep(4000);
            
            for (int i = 0; i < 1000; i++)
            {
                eventStreaming.SendAsync(Events.LOGGED_IN());
            }

            System.Console.ReadLine();
        }
    }
}
