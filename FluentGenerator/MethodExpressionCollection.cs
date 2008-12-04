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
            throw new System.NotImplementedException();
        }
    }
}
