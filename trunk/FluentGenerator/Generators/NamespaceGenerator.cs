using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Generators
{
    public class NamespaceGenerator : INamespaceGenerator
    {
        private IList<IGeneratable> _generatableItems = new List<IGeneratable>();

        public string Name { get; set; }
        public IList<IGeneratable> GeneratableItems
        {
            get { return _generatableItems; }
        }

        public void Generate(ICodeWriter codeWriter)
        {
            codeWriter.AppendLineFormat("namespace {0}", Name);
            codeWriter.AppendLine("{");
            codeWriter.IncreaseIndent();

            foreach (IGeneratable item in GeneratableItems)
                item.Generate(codeWriter);

            codeWriter.DecreaseIndent();
            codeWriter.AppendLine("}");
            codeWriter.AppendLine();
        }
    }
}
