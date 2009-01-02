using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Generators
{
    public class FieldGeneratorCollection : List<IFieldGenerator>, IFieldGeneratorCollection
    {
        public void Generate(ICodeWriter codeWriter)
        {
            foreach (var fieldExpression in this)
                fieldExpression.Generate(codeWriter);
        }
    }
}
