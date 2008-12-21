using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class MethodExpressionCollection : List<IMethodExpression>, IMethodExpressionCollection
    {
        public void Generate(ICodeWriter codeWriter)
        {
            foreach (IMethodExpression method in this)
                method.Generate(codeWriter);
        }
    }
}
