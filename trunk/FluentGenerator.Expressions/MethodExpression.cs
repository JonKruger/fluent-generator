using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Generators;

namespace FluentGenerator.Expressions
{
    public class MethodExpression : IMethodExpression
    {
        private IMethodGenerator _generator = new MethodGenerator();

        public IMethodGenerator Generator
        {
            get { return _generator; }
        }
    }
}
