using System;
using System.Collections.Generic;
using System.Text;
using FluentGenerator.Generators;

namespace FluentGenerator.Expressions
{
    public class PropertyExpression : ClassExpression, IPropertyExpression
    {
        private IPropertyGenerator _generator;
        private IClassGenerator _parentClassGenerator;

        public IPropertyGenerator Generator
        {
            get { return _generator; }
        }

        public override IClassGenerator CurrentClassGenerator
        {
            get
            {
                return _parentClassGenerator;
            }
        }

        public PropertyExpression(IGeneratorFactory generatorFactory, IClassGenerator parentClassGenerator) : base(generatorFactory)
        {
            _generator = generatorFactory.CreatePropertyGenerator();
            _parentClassGenerator = parentClassGenerator;
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