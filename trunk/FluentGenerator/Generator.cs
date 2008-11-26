using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator
{
    public abstract class Generator : IGenerator
    {
        private static Generator _current;

        public static Generator Current
        {
            get { return _current; }
        }

        public Generator()
        {
            _current = this;
        }

        public abstract void Generate();

        public void GenerateFile(OutputFile file)
        {
            throw new NotImplementedException();
        }

        protected ClassData CreateClass()
        {
            return CreateClass(null);
        }

        protected ClassData CreateClass(string className)
        {
            ClassData classData = new ClassData();
            OutputFile.Current.AddClass(classData);

            if (!string.IsNullOrEmpty(className))
                classData.WithName(className);
            return classData;
        }

    }
}
