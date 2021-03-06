﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EventStream.Abstractions;
using Newtonsoft.Json;

namespace EventStream.Console.Sample
{
    internal class HttpSender : IEventSender
    {
        private readonly string _url;
        private readonly Encoding _utf8WithoutBom = new UTF8Encoding(false);

        public HttpSender(string url)
        {
            _url = url;
        }

        public async void SendEvents(IList<Event> events, Action<bool> callback)
        {
            var jsonBytes = SerializeToJson(events);

            var nameValueCollection = new[]
                {new KeyValuePair<string, string>("records", Encoding.UTF8.GetString(jsonBytes, 0, jsonBytes.Length))};
            var content = new FormUrlEncodedContent(nameValueCollection);

            try
            {
                await new HttpClient().PostAsync(_url, content);
                callback(true);
            }
            catch
            {
                System.Console.WriteLine("Error while sending events");
                callback(false);
            }
        }

        private byte[] SerializeToJson(IEnumerable<Event> events)
        {
            var memoryStream = new MemoryStream();

            using (var writer = new StreamWriter(memoryStream))
            {
                using (var jsonTextWriter = new JsonTextWriter(writer))
                {
                    var jsonSerializer = new JsonSerializer();
                    jsonTextWriter.Formatting = Formatting.None;
                    jsonSerializer.Serialize(jsonTextWriter,
                        events.Select(ev => ev.Fields.ToDictionary(kv => kv.Key, kv => kv.Value)));
                }
            }

            var rawData = memoryStream.ToArray();

            return rawData;
        }
    }
}