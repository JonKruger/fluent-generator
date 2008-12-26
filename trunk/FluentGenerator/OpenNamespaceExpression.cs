using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class OpenNamespaceExpression : IOpenNamespaceExpression
    {
        private string _name;
        private IGenerator _generator;

        public OpenNamespaceExpression(IGenerator generator)
        {
            _generator = generator;
        }

        public void Generate(ICodeWriter codeWriter)
        {
            codeWriter.AppendLineFormat("namespace {0}", _name);
            codeWriter.AppendLine("{");
            codeWriter.IncreaseIndent();
        }

        public OpenNamespaceExpression WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}
