namespace EventStream.Configuration
{
    public class DynamicFieldDefinition : IFieldDefinition
    {
        public DynamicFieldDefinition(string name, string fieldType)
        {
            Name = name;
            Type = fieldType;
        }

        public string Type { get; }

        public string Name { get; }

        public override string ToString()
        {
            return $"{Name} : #{Type}";
        }
    }
}