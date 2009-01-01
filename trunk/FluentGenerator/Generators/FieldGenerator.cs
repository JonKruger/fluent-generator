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
            codeWriter.AppendLineFormat("public {0} {1};", Type, Name.ToCamelCaseUnderscore());
        }
    }
}
