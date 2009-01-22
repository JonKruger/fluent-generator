using System.Collections.Generic;

namespace FluentGenerator.Generators
{
    public interface IPropertyGeneratorCollection : IGeneratable, IList<IPropertyGenerator>
    {
    }
}