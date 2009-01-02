using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Generators
{
    public class PropertyGenerator : IPropertyGenerator
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public virtual void Generate(ICodeWriter codeWriter)
        {
            var backingField = ExtractBackingFieldExpression();
            if (backingField != null)
            {
                backingField.Generate(codeWriter);
                codeWriter.AppendLine();
            }
            GeneratePropertyOnly(codeWriter);
        }

        public virtual IFieldGenerator ExtractBackingFieldExpression()
        {
            return null;
            //return new FieldExpression(Generator).OfType(Type).WithName(Name);
        }

        public virtual void GeneratePropertyOnly(ICodeWriter codeWriter)
        {
            if (Type == null)
                throw new GenerationException(string.Format("Property type was not set (property name = {0}).", Name ?? string.Empty));
            if (Name == null)
                throw new GenerationException(string.Format("Property name was not set (property type = {0}).", Type ?? string.Empty));

            codeWriter.AppendLineFormat("public {0} {1} {{ get; set; }}", Type, Name);
        }
    }
}
