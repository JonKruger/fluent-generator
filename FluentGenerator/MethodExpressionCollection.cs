using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class MethodExpressionCollection : List<IMethodExpression>, IMethodExpressionCollection
    {
        public IGenerationOutput Generate()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IMethodExpression method in this)
                sb.AppendLine(method.Generate().Output.ToString());
            return new GenerationOutput(sb.ToString());
        }
    }
}
