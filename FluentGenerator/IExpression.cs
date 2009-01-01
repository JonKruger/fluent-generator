using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public interface IExpression<T> where T : IGeneratable
    {
        T Generator { get; }
    }
}
