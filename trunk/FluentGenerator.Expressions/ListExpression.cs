using System;
using System.Collections.Generic;
using FluentGenerator.Generators;

namespace FluentGenerator.Expressions
{
    public class ListExpression : ClassExpression, IPropertyExpression
    {
        private IPropertyGenerator _generator;

        public IPropertyGenerator Generator
        {
            get { return _generator; }
        }

        public ListExpression(IGeneratorFactory generatorFactory) : base(generatorFactory)
        {
            _generator = generatorFactory.CreatePropertyGenerator();
        }

        public ListExpression Of(string objectType)
        {
            _generator.Type = string.Format("List<{0}>", objectType);
            return this;
        }

        public new ListExpression WithName(string name)
        {
            _generator.Name = name;
            return this;
        }
    }
}