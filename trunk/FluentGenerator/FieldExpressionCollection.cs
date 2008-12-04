using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class FieldExpressionCollection : List<IFieldExpression>, IFieldExpressionCollection
    {
        public IGenerationOutput Generate()
        {
            StringBuilder output = new StringBuilder();
            foreach (var fieldExpression in this)
                output.Append(fieldExpression.Generate().Output.ToString());
            return new GenerationOutput(output.ToString());
        }
    }
}
