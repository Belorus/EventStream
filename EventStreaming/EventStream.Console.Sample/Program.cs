﻿using System.IO;
using EventStreaming;
using EventStreaming.Configuration;

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
                new BufferingEventDispatcher(new HttpSender("http://estream.playtika.com/CL/")){ MaxQueueSize = 0 }, 
                config);

            eventStreaming.QueueSending(GeneratedEvents.LOGGED_IN("123", "155"));

            System.Console.ReadLine();
        }
    }
}