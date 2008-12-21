using System.Collections.Generic;

namespace FluentGenerator
{
    public interface IPropertyExpression : IGeneratable
    {
        IFieldExpression ExtractBackingFieldExpression();
        void GeneratePropertyOnly(ICodeWriter codeWriter);
    }
}