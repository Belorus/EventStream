using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EventStreaming;
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

        public async Task<bool> SendEvents(Event[] events)
        {
            var httpClient = new HttpClient();

            var preresultStream = new MemoryStream();

            using (StreamWriter writer = new StreamWriter(preresultStream, _utf8WithoutBom, 512, true))
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(writer))
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    jsonTextWriter.Formatting = Formatting.None;
                    jsonSerializer.Serialize(jsonTextWriter, events);
                }
            }

            var rawData = preresultStream.ToArray();

            var nameValueCollection = new[] { new KeyValuePair<string, string>("records", Encoding.UTF8.GetString(rawData, 0, rawData.Length)) };
            var content = new FormUrlEncodedContent(nameValueCollection);

            try
            {
                await httpClient.PostAsync(_url, content);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}