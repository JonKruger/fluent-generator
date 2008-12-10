using System.Collections.Generic;

namespace FluentGenerator
{
    public interface IPropertyExpression : IGeneratable
    {
        IFieldExpression ExtractBackingFieldExpression();
        string GeneratePropertyOnly();
    }
}