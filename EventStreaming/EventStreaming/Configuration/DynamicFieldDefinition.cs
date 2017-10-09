namespace EventStreaming.Configuration
{
    public class DynamicFieldDefinition : IFieldDefinition
    {
        public DynamicFieldDefinition(string name, ConfigParser.FieldType fieldType)
        {
            Name = name;
            Type = fieldType;
        }

        public ConfigParser.FieldType Type { get; }

        public string Name { get; }

        public override string ToString()
        {
            return $"{Name} : #{Type}";
        }
    }
}