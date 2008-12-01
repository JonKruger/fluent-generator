using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Service;
using StructureMap;

namespace FluentGenerator
{
    public abstract class Generator : IGenerator
    {
        private static IGenerator _current;
        private IFileSystemService _fileSystemService;

        public static IGenerator Current
        {
            get { return _current; }
        }

        public Generator(IFileSystemService fileSystemService) 
        {
            _current = this;
            _fileSystemService = fileSystemService;
        }

        public Generator()
        {
            _current = this;
            _fileSystemService = ObjectFactory.GetInstance<IFileSystemService>();
        }

        public abstract void Generate();

        public virtual void GenerateFile(OutputFile file)
        {
            foreach (var item in file.GeneratableItems)
            {
                string generatedStuff = item.Generate();
                _fileSystemService.WriteToFile(file.Path, generatedStuff);
            }
        }

        protected ClassData CreateClass()
        {
            return CreateClass(null);
        }

        protected ClassData CreateClass(string className)
        {
            ClassData classData = new ClassData();
            OutputFile.Current.AddGeneratableItem(classData);

            if (!string.IsNullOrEmpty(className))
                classData.WithName(className);
            return classData;
        }

    }
}
