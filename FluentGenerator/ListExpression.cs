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

        public IFieldExpression ExtractBackingFieldExpression()
        {
            return null;
            //return new FieldExpression(Generator).OfType(string.Format("IList<{0}>", _objectType)).WithName(_name);
        }

        public void GeneratePropertyOnly(ICodeWriter codeWriter)
        {
            if (_objectType == null)
                throw new GenerationException(string.Format("List type was not set (property name = {0}).", _name));
            if (_name == null)
                throw new GenerationException(string.Format("List name was not set (property type = {0}).", _objectType));

            codeWriter.AppendLineFormat("public {0} {1} {{ get; set; }}", string.Format("IList<{0}>", _objectType), _name);
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