using System;
using System.IO;
using System.Threading;
using BB;
using EventStreaming;
using EventStreaming.Configuration;
using EventStreaming.Dispatchers;

namespace EventStream.Console.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigParser(File.OpenRead("config.json")).ReadFullConfig();
            var context = new AmbientContext();
            var eventStreaming = new EventStreaming.EventStream(
                context,
                new BufferingEventDispatcher(new ConsoleEventSender()),
                new EventStreamSettings(),
                config);

            context.SetAppVersion("1.01");
            context.SetOsName("Windows");
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