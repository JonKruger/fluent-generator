using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class CloseNamespaceExpression : ICloseNamespaceExpression
    {
        private IGenerator _generator;

        public CloseNamespaceExpression(IGenerator generator)
        {
            _generator = generator;
        }

        public void Generate(ICodeWriter codeWriter)
        {
            codeWriter.DecreaseIndent();
            codeWriter.AppendLine("}");
            codeWriter.AppendLine();
        }
    }
}
