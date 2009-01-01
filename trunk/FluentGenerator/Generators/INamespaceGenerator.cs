using System.Collections.Generic;

namespace FluentGenerator.Generators
{
    public interface INamespaceGenerator : IGeneratable
    {
        string Name { get; set; }
        IList<IGeneratable> GeneratableItems { get; }
    }
}