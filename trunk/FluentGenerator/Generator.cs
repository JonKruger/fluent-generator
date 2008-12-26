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
        private IOpenNamespaceExpression _currentNamespace;

        public static IGenerator Current
        {
            get { return _current; }
        }

        public IOpenNamespaceExpression CurrentNamespace { get; set; }

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
            file.GenerateFile();
        }

        public ClassExpression CreateClass()
        {
            return CreateClass(null);
        }

        public ClassExpression CreateClass(string className)
        {
            ClassExpression classData = new ClassExpression(this);
            OutputFile.Current.AddGeneratableItem(classData);

            if (!string.IsNullOrEmpty(className))
                classData.WithName(className);
            return classData;
        }

        public void Namespace(string ns)
        {
            if (_currentNamespace != null)
                OutputFile.Current.AddGeneratableItem(new CloseNamespaceExpression(this));
            _currentNamespace = new OpenNamespaceExpression(this).WithName(ns);
            OutputFile.Current.AddGeneratableItem(_currentNamespace);
        }
    }
}
