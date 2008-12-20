using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class PropertyExpressionCollection : List<IPropertyExpression>, IPropertyExpressionCollection
    {
        public IGenerationOutput Generate()
        {
            StringBuilder output = new StringBuilder();

            List<IFieldExpression> backingFields = new List<IFieldExpression>();
            foreach (var propertyExpression in this)
                backingFields.Add(propertyExpression.ExtractBackingFieldExpression());

            foreach (var field in backingFields)
                output.AppendLine(field.Generate().Output.ToString());
    
            if (output.Length > 0)
                output.AppendLine();
            
            foreach (var propertyExpression in this)
                output.AppendLine(propertyExpression.GeneratePropertyOnly());

            return new GenerationOutput(output.ToString());
        }
    }
}
