using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class NamespaceExpression : INamespaceExpression
    {
        private string _name;
        private IGenerator _generator;
        private List<IGeneratable> _generatableItems = new List<IGeneratable>();

        public List<IGeneratable> GeneratableItems
        {
            get { return _generatableItems; }
        }

        public NamespaceExpression(IGenerator generator)
        {
            _generator = generator;
        }

        public void Generate(ICodeWriter codeWriter)
        {
            codeWriter.AppendLineFormat("namespace {0}", _name);
            codeWriter.AppendLine("{");
            codeWriter.IncreaseIndent();

            foreach (IGeneratable item in GeneratableItems)
                item.Generate(codeWriter);

            codeWriter.DecreaseIndent();
            codeWriter.AppendLine("}");
            codeWriter.AppendLine();
        }

        public NamespaceExpression WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}
