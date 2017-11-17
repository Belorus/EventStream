using System;

namespace EventStreaming.Configuration
{
    public class ReferenceFieldDefinition : IFieldDefinition
    {
        public ReferenceFieldDefinition(string name, IFieldDefinition referencedField)
        {
            Name = name;
            ReferencedField = referencedField;
        }

        public string Name { get; }
        public IFieldDefinition ReferencedField { get; }

        public override string ToString()
        {
            return $"{Name} : @{ReferencedField}>";
        }
    }
}