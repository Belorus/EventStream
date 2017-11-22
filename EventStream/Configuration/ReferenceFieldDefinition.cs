namespace EventStream.Configuration
{
    public class ReferenceFieldDefinition : IFieldDefinition
    {
        public ReferenceFieldDefinition(string name, IFieldDefinition referencedField)
        {
            Name = name;
            ReferencedField = referencedField;
        }

        public IFieldDefinition ReferencedField { get; }

        public string Name { get; }

        public override string ToString()
        {
            return $"{Name} : @{ReferencedField}>";
        }
    }
}