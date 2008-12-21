using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public class PropertyExpressionCollection : List<IPropertyExpression>, IPropertyExpressionCollection
    {
        public void Generate(ICodeWriter codeWriter)
        {
            List<IFieldExpression> backingFields = new List<IFieldExpression>();
            foreach (var propertyExpression in this)
            {
                var backingField = propertyExpression.ExtractBackingFieldExpression();
                if (backingField != null)
                    backingFields.Add(backingField);
            }
            foreach (var field in backingFields)
                field.Generate(codeWriter);

            if (backingFields.Count > 0)
                codeWriter.AppendLine();
            
            foreach (var propertyExpression in this)
                propertyExpression.GeneratePropertyOnly(codeWriter);
        }
    }
}
