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

            List<PropertyWithBackingField> propertiesWithBackingFields = new List<PropertyWithBackingField>();
            foreach (var propertyExpression in this)
                propertiesWithBackingFields.Add(propertyExpression.GeneratePropertyWithBackingField());

            foreach (var field in propertiesWithBackingFields.Select(pwbf => pwbf.BackingFieldText))
                output.AppendLine(field);
            output.AppendLine();
            foreach (var property in propertiesWithBackingFields.Select(pwbf => pwbf.PropertyText))
                output.AppendLine(property);

            return new GenerationOutput(output.ToString());
        }
    }
}
