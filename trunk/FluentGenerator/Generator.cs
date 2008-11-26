using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public abstract class Generator : IGenerator
    {
        public abstract void Generate();

        protected ClassData CreateClass()
        {
            return new ClassData();
        }

        protected ClassData CreateClass(string className)
        {
            return new ClassData().WithName(className);
        }
    }
}
