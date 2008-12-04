using System;

namespace FluentGenerator
{
    public class PropertyExpression : ClassExpression, IPropertyExpression
    {
        private ClassExpression _parent;
        private string _name;
        private string _type;

        public PropertyExpression(ClassExpression parent)
        {
            _parent = parent;
        }

        public override IGenerationOutput Generate()
        {
            throw new NotImplementedException();            
        }

        public PropertyWithBackingField GeneratePropertyWithBackingField()
        {
            PropertyWithBackingField result = new PropertyWithBackingField();
            throw new NotImplementedException();
        }

        public new PropertyExpression WithName(string name)
        {
            _name = name;
            return this;
        }

        public PropertyExpression OfType(string type)
        {
            _type = type;
            return this;
        }
    }
}