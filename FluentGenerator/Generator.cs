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
        private ICodeWriter _codeWriter;

        public static IGenerator Current
        {
            get { return _current; }
        }

        public ICodeWriter Writer
        {
            get
            {
                return _codeWriter;
            }
        }

        public Generator(IFileSystemService fileSystemService, ICodeWriter codeWriter) 
        {
            _current = this;
            _fileSystemService = fileSystemService;
            _codeWriter = codeWriter;
        }

        public Generator()
        {
            _current = this;
            _fileSystemService = ObjectFactory.GetInstance<IFileSystemService>();
            _codeWriter = ObjectFactory.GetInstance<ICodeWriter>();
        }

        public abstract void Generate();

        public virtual void GenerateFile(OutputFile file)
        {
            //foreach (var item in file.GeneratableItems)
            //{
            //    string generatedStuff = item.Generate();
            //    _fileSystemService.WriteToFile(file.Path, generatedStuff);
            //}
        }

        protected ClassExpression CreateClass()
        {
            return CreateClass(null);
        }

        protected ClassExpression CreateClass(string className)
        {
            ClassExpression classData = new ClassExpression(this);
            OutputFile.Current.AddGeneratableItem(classData);

            if (!string.IsNullOrEmpty(className))
                classData.WithName(className);
            return classData;
        }
    }
}
