using System.Collections.Generic;
using FluentGenerator.Generators;

namespace FluentGenerator
{
    public interface INamespaceExpression : IExpression<INamespaceGenerator>
    {
        void AddGeneratableItem(IGeneratable item);
    }
}