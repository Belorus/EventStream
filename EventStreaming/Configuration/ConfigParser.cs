using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace EventStreaming.Configuration
{
    public partial class ConfigParser
    {
        private readonly Stream _configDataStream;

        public ConfigParser(Stream configDataStream)
        {
            _configDataStream = configDataStream;
        }

        public FullEventsConfiguration ReadFullConfig()
        {
            using (StreamReader sr = new StreamReader(_configDataStream))
            {
                var root = JObject.Parse(sr.ReadToEnd());
                var fields = (JObject) root.Property("fields").Value;
                var groups = (JArray) root.Property("groups").Value;

                var ambientFieldDefinitions = ParseFields(fields);

                var allEvents = ParseGroups(groups, new Dictionary<string, IFieldDefinition>(), 100)
                    .ToDictionary(e => e.Name, e => e);

                return new FullEventsConfiguration(allEvents, ambientFieldDefinitions);
            }
        }

        private static Dictionary<string, IFieldDefinition> ParseFields(JObject fields)
        {
            Dictionary<string, IFieldDefinition> fieldDefinitions =
                new Dictionary<string, IFieldDefinition>(fields.Count);

            foreach (var fieldToken in fields)
            {
                string fieldValue = fieldToken.Value.ToString();

                if (fieldValue.StartsWith("#", StringComparison.Ordinal))
                {
                    fieldDefinitions[fieldToken.Key] = new DynamicFieldDefinition(fieldToken.Key,
                        (FieldType) Enum.Parse(typeof(FieldType), fieldValue.Substring(1), true));
                }
                else if (fieldValue.StartsWith("$", StringComparison.Ordinal))
                {
                    fieldDefinitions[fieldToken.Key] = new EvaluatedFieldDefinition(fieldToken.Key,
                        (FieldType) Enum.Parse(typeof(FieldType), fieldValue.Substring(1), true));
                } 
                else
                {
                    fieldDefinitions[fieldToken.Key] = new StaticFieldDefinition(fieldToken.Key, fieldValue);
                }
            }

            return fieldDefinitions;
        }

        private IEnumerable<EventDefinition> ParseGroups(
            JArray groups,
            Dictionary<string, IFieldDefinition> inheritedFieldDefinitions,
            double? inheritedSampleRate)
        {
            foreach (var ev in groups.Cast<JObject>())
            {
                var fieldsProperty = ev.Property("fields");
                var fieldDefinitions = (fieldsProperty != null
                        ? ParseFields((JObject) fieldsProperty.Value)
                        : new Dictionary<string, IFieldDefinition>())
                    .Union(inheritedFieldDefinitions)
                    .ToDictionary(kv => kv.Key, kv => kv.Value);

                var percentProperty = ev.Property("percent");
                var percent = percentProperty != null
                    ? (double) percentProperty.Value
                    : inheritedSampleRate ?? 0;

                var groupsProperty = ev.Property("groups");
                if (groupsProperty == null)
                {
                    var eventsProperty = ev.Property("events");
                    foreach (var item in ParseEvents(
                        (JArray) eventsProperty.Value,
                        fieldDefinitions,
                        percent))
                    {
                        yield return item;
                    }
                }
                else
                {
                    foreach (var item in ParseGroups(
                        (JArray) groupsProperty.Value,
                        fieldDefinitions,
                        percent))
                    {
                        yield return item;
                    }
                }
            }
        }


        private IEnumerable<EventDefinition> ParseEvents(
            JArray events,
            Dictionary<string, IFieldDefinition> inheritedFieldDefinitions,
            double? inheritedSampleRate)
        {
            foreach (var ev in events.Cast<JObject>())
            {
                var fieldsProperty = ev.Property("fields");
                var fieldDefinitions = (fieldsProperty != null
                        ? ParseFields((JObject) fieldsProperty.Value)
                        : new Dictionary<string, IFieldDefinition>())
                    .Union(inheritedFieldDefinitions)
                    .ToDictionary(kv => kv.Key, kv => kv.Value);

                var percentProperty = ev.Property("percent");
                var percent = percentProperty != null
                    ? (double) percentProperty.Value
                    : inheritedSampleRate ?? 0;

                var id = ev.Property("id").Value.ToString();

                yield return new EventDefinition(fieldDefinitions, percent, id);
            }
        }
    }
}
