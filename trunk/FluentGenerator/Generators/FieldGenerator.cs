using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Extensions;

namespace FluentGenerator.Generators
{
    public class FieldGenerator : IFieldGenerator
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual void Generate(ICodeWriter codeWriter)
        {
            if (Type == null)
                throw new GenerationException(string.Format("Field type was not set (field name = {0}).", Name ?? string.Empty));
            if (Name == null)
                throw new GenerationException(string.Format("Field name was not set (field type = {0}).", Type ?? string.Empty));


            codeWriter.AppendLineFormat("public {0} {1};", Type, Name.ToCamelCaseUnderscore());
        }
    }
}
