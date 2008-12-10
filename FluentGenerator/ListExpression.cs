using System;
using System.Collections.Generic;

namespace FluentGenerator
{
    public class ListExpression : ClassExpression, IPropertyExpression
    {
        private ClassExpression _parent;
        private string _objectType;
        private string _name;

        public ListExpression(ClassExpression parent)
        {
            _parent = parent;
        }

        public override IGenerationOutput Generate()
        {
            throw new NotImplementedException();
        }

        public IFieldExpression ExtractBackingFieldExpression()
        {
            throw new System.NotImplementedException();
        }

        public string GeneratePropertyOnly()
        {
            throw new System.NotImplementedException();
        }

        public ListExpression Of(string objectType)
        {
            _objectType = objectType;
            return this;
        }

        public new ListExpression WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}