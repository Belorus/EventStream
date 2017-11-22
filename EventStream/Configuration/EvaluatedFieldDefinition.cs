namespace EventStream.Configuration
{
    public class EvaluatedFieldDefinition : IFieldDefinition
    {
        public EvaluatedFieldDefinition(string name, ConfigParser.FieldType fieldType)
        {
            Name = name;
            Type = fieldType;
        }

        public ConfigParser.FieldType Type { get; }

        public string Name { get; }

        public override string ToString()
        {
            return $"{Name} : Func<{Type}>";
        }
    }
}