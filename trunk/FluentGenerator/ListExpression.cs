using System;
using System.Collections.Generic;

namespace FluentGenerator
{
    public class ListExpression : ClassExpression, IPropertyExpression
    {
        private ClassExpression _parent;
        private string _objectType;
        private string _name;

        public ListExpression(ClassExpression parent) : base(parent.Generator)
        {
            _parent = parent;
        }

        public override IGenerationOutput Generate()
        {
            var output = string.Format("public IList<{0}> {1} {{ get; set; }}", _objectType, _name);
            return new GenerationOutput(output);
        }

        public IFieldExpression ExtractBackingFieldExpression()
        {
            return new FieldExpression(Generator).OfType(string.Format("IList<{0}>", _objectType)).WithName(_name);
        }

        public string GeneratePropertyOnly()
        {
            return string.Format("public {0} {1} {{ get; set; }}", string.Format("IList<{0}>", _objectType), _name);
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