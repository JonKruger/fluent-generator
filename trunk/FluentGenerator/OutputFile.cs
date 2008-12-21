using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentGenerator.Service;
using StructureMap;

namespace FluentGenerator
{
    public class OutputFile : IDisposable
    {
        private static OutputFile _current;
        private List<IGeneratable> _generatableItems = new List<IGeneratable>();
        private IFileSystemService _fileSystemService;

        public static OutputFile Current
        {
            get { return _current; }
            set { _current = value; }
        }

        public List<IGeneratable> GeneratableItems
        {
            get { return _generatableItems; }
        }

        public string Path { get; private set; }

        public OutputFile(string path)
            : this(path, ObjectFactory.GetInstance<IFileSystemService>())
        {
        }

        public OutputFile(string path, IFileSystemService fileSystemService)
        {
            if (_current != null)
                throw new InvalidOperationException("A new OutputFile cannot be created until the previous one has been disposed.");

            Path = path;
            _current = this;
            _fileSystemService = fileSystemService;
        }

        public void AddGeneratableItem(IGeneratable item)
        {
            _generatableItems.Add(item);
        }

        public virtual void GenerateFile()
        {
            foreach (var item in GeneratableItems)
            {
                CodeWriter codeWriter = new CodeWriter();
                item.Generate(codeWriter);
                _fileSystemService.WriteToFile(Path, codeWriter.ToString());
            }
        }

        public void Dispose()
        {
            Generator.Current.GenerateFile(this);
            _current = null;
        }
    }
}