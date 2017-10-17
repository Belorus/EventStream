﻿using System.Collections.Generic;

namespace EventStreaming.Configuration
{
    public class EventDefinition
    {
        public readonly double Percent;
        public readonly Dictionary<string, IFieldDefinition> Fields;
        public readonly string Name;

        public EventDefinition(
            Dictionary<string, IFieldDefinition> fieldDefinitions,
            double percent,
            string name)
        {
            Percent = percent;
            Fields = fieldDefinitions;
            Name = name;
        }
    }
}