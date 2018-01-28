using System;
using System.IO;
using System.Linq;
using System.Threading;
using EventStream.Configuration;
using EventStream.Dispatchers;
using EventStream.Senders;

namespace EventStream.Console.Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = new ConfigParser(File.OpenRead("config.json")).ReadFullConfig();
            var context = new AmbientContext();
            var eventStreaming = new EventStream(
                context,
                new BufferingEventDispatcher(new DelegateEventSender((events, callback) =>
                {
                    foreach (var e in events)
                    {
                        System.Console.WriteLine($"{e.Name}: {string.Join(",",e.Fields.Select(f => string.Format($"{f.Key}={f.Value}")))}");
                    }
                    callback(true);
                })),
                new EventStreamSettings(),
                config);

            eventStreaming.BeforeDispatchInterceptor = new ReplaceGroupInDevBuildInterceptor();

            context.SetAppVersion("1.01");
            context.SetOsName("Windows");
            context.SetUserId("123");
            context.SetSessionId("1234");
            context.SetTimestampFunc(() => DateTime.Now.Millisecond);

            for (int i = 0; i < 100; i++)
            {
                eventStreaming.SendAsync(Events.LOGGED_IN());
            }

            System.Console.ReadLine();
        }
    }
}