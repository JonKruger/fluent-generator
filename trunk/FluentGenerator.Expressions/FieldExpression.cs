using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Generators;
using FluentGenerator.Extensions;

namespace FluentGenerator.Expressions
{
    public class FieldExpression : ClassExpression, IFieldExpression
    {
        private IFieldGenerator _generator;

        public IFieldGenerator Generator
        {
            get { return _generator; }
        }

        public FieldExpression(IGeneratorFactory generatorFactory) : base(generatorFactory)
        {
            _generator = generatorFactory.CreateFieldGenerator();
        }

        public new FieldExpression WithName(string name)
        {
            _generator.Name = name;
            return this;
        }

        public FieldExpression OfType(string type)
        {
            _generator.Type = type;
            return this;
        }
    }
}
