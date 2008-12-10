using System;
using System.Collections.Generic;

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

        public IFieldExpression ExtractBackingFieldExpression()
        {
            throw new NotImplementedException();
        }

        public string GeneratePropertyOnly()
        {
            throw new System.NotImplementedException();
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