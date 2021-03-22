namespace EventStream.Configuration
{
    public class EvaluatedFieldDefinition : IFieldDefinition
    {
        public EvaluatedFieldDefinition(string name, string fieldType)
        {
            Name = name;
            Type = fieldType;
        }

        public string Type { get; }

        public string Name { get; }

        public override string ToString()
        {
            return $"{Name} : Func<{Type}>";
        }
    }
}