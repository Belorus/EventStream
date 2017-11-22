namespace EventStream.Configuration
{
    public class StaticFieldDefinition : IFieldDefinition
    {
        public StaticFieldDefinition(string name, string value)
        {
            Value = value;
            Name = name;
        }

        public string Value { get; }

        public string Name { get; }

        public override string ToString()
        {
            return $"{Name} : `{Value}`";
        }
    }
}