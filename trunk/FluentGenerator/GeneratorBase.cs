using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Service;
using StructureMap;

namespace FluentGenerator
{
    public abstract class GeneratorBase : IGenerator
    {
        private static IGenerator _current;
        protected IFileSystemService _fileSystemService;
        protected IGeneratorFactory _generatorFactory;

        public static IGenerator Current
        {
            get { return _current; }
        }

        protected IFileSystemService FileSystemService
        {
            get { return _fileSystemService; }
        }

        protected IGeneratorFactory GeneratorFactory
        {
            get { return _generatorFactory; }
        }

        public GeneratorBase(IGeneratorFactory generatorFactory, IFileSystemService fileSystemService) 
        {
            _current = this;
            _generatorFactory = generatorFactory;
            _fileSystemService = fileSystemService;
        }

        public GeneratorBase()
        {
            ObjectFactory.Configure(x =>
            {
                x.AddRegistry<FluentGeneratorRegistry>();
            });
            
            _current = this;
            _generatorFactory = ObjectFactory.GetInstance<IGeneratorFactory>();
            _fileSystemService = ObjectFactory.GetInstance<IFileSystemService>();
        }

        public virtual void Generate()
        {
            throw new System.NotImplementedException();
        }

        public virtual void GenerateFile(OutputFile file)
        {
            file.GenerateFile();
        }
    }
}
