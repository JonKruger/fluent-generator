using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Generators
{
    public class MethodGeneratorCollection : List<IMethodGenerator>, IMethodGeneratorCollection
    {
        public virtual void Generate(ICodeWriter codeWriter)
        {
            foreach (var method in this)
                method.Generate(codeWriter);
        }
    }
}
