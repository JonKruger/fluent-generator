using System.Collections.Generic;

namespace FluentGenerator
{
    public interface INamespaceExpression : IGeneratable
    {
        List<IGeneratable> GeneratableItems { get; }
    }
}