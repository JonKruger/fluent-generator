using System.Collections.Generic;

namespace FluentGenerator.Generators
{
    public interface IFieldGeneratorCollection : IGeneratable, IList<IFieldGenerator>
    {
    }
}