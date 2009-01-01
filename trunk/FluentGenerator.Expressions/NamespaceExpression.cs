using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Generators;

namespace FluentGenerator.Expressions
{
    public class NamespaceExpression : INamespaceExpression
    {
        private INamespaceGenerator _generator = new NamespaceGenerator();

        public INamespaceGenerator Generator
        {
            get { return _generator; }
        }

        public NamespaceExpression WithName(string name)
        {
            _generator.Name = name;
            return this;
        }

        public void AddGeneratableItem(IGeneratable item)
        {
            _generator.GeneratableItems.Add(item);
        }
    }
}
