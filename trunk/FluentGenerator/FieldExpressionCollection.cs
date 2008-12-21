using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class FieldExpressionCollection : List<IFieldExpression>, IFieldExpressionCollection
    {
        public void Generate(ICodeWriter codeWriter)
        {
            foreach (var fieldExpression in this)
                fieldExpression.Generate(codeWriter);
        }
    }
}
