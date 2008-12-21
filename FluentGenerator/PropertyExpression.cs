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

        public override void Generate(ICodeWriter codeWriter)
        {
            var backingField = ExtractBackingFieldExpression();
            if (backingField != null)
            {
                backingField.Generate(codeWriter);
                codeWriter.AppendLine();
            }
            GeneratePropertyOnly(codeWriter);
        }

        public virtual IFieldExpression ExtractBackingFieldExpression()
        {
            return null;
            //return new FieldExpression(Generator).OfType(_type).WithName(_name);
        }

        public virtual void GeneratePropertyOnly(ICodeWriter codeWriter)
        {
            if (_type == null)
                throw new GenerationException(string.Format("Property type was not set (property name = {0}).", _name));
            if (_name == null)
                throw new GenerationException(string.Format("Property name was not set (property type = {0}).", _type));

            codeWriter.AppendLineFormat("public {0} {1} {{ get; set; }}", _type, _name);
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