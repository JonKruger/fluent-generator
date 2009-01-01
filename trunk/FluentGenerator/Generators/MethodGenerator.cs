using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Generators
{
    public class MethodGenerator : IMethodGenerator
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }

        public void Generate(ICodeWriter codeWriter)
        {
            if (string.IsNullOrEmpty(Name))
                throw new GenerationException("Method name was not specified.");
            if (string.IsNullOrEmpty(ReturnType))
                throw new GenerationException("Method return type was not specified.");

            codeWriter.AppendLineFormat("public {0} {1}()", ReturnType, Name);
            codeWriter.AppendLine("{");
            codeWriter.AppendLine("}");
        }
    }
}
