using System;
using System.Collections.Generic;
using System.Text;
using FluentGenerator.Generators;

namespace FluentGenerator.Expressions
{
    public class PropertyExpression : ClassExpression, IPropertyExpression
    {
        private IPropertyGenerator _generator;

        public IPropertyGenerator Generator
        {
            get { return _generator; }
        }

        public PropertyExpression(IGeneratorFactory generatorFactory) : base(generatorFactory)
        {
            _generator = generatorFactory.CreatePropertyGenerator();
        }

        public new PropertyExpression WithName(string name)
        {
            _generator.Name = name;
            return this;
        }

        public PropertyExpression OfType(string type)
        {
            _generator.Type = type;
            return this;
        }
    }
}