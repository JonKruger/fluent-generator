using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;

namespace FluentGenerator
{
    public class FieldExpression : ClassExpression, IFieldExpression
    {
        private string _name;
        private string _type;

        public FieldExpression(IGenerator generator) : base(generator)
        {
        }

        public override void Generate(ICodeWriter codeWriter)
        {
            codeWriter.AppendLineFormat("public {0} {1};", _type, _name.ToCamelCaseUnderscore());
        }

        public new FieldExpression WithName(string name)
        {
            _name = name;
            return this;
        }

        public FieldExpression OfType(string type)
        {
            _type = type;
            return this;
        }
    }
}
