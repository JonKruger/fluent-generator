using System.Collections.Generic;

namespace FluentGenerator.Generators
{
    public interface IMethodGeneratorCollection : IGeneratable, IList<IMethodGenerator>
    {
    }
}