using System;
using System.Collections.Generic;
using System.Text;

namespace FluentGenerator
{
    public class PropertyExpression : ClassExpression, IPropertyExpression
    {
        private ClassExpression _parent;
        private string _name;
        private string _type;

        public PropertyExpression(ClassExpression parent) : base(parent.Generator)
        {
            _parent = parent;
        }

        public override IGenerationOutput Generate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ExtractBackingFieldExpression().Generate().Output.ToString());
            sb.AppendLine();
            sb.AppendLine(GeneratePropertyOnly());
            return new GenerationOutput(sb.ToString());
        }

        public virtual IFieldExpression ExtractBackingFieldExpression()
        {
            return new FieldExpression(Generator).OfType(_type).WithName(_name);
        }

        public virtual string GeneratePropertyOnly()
        {
            return string.Format("public {0} {1} {{ get; set; }}", _type, _name);
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