using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Generators
{
    public class PropertyGeneratorCollection : List<IPropertyGenerator>, IGeneratable
    {
        public void Generate(ICodeWriter codeWriter)
        {
            List<IFieldGenerator> backingFields = new List<IFieldGenerator>();
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
