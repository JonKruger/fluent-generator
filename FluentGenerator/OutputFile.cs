using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FluentGenerator
{
    public class OutputFile : IDisposable
    {
        private static OutputFile _current;
        private List<IGeneratable> _generatableItems = new List<IGeneratable>();

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
        {
            if (_current != null)
                throw new InvalidOperationException("A new OutputFile cannot be created until the previous one has been disposed.");

            Path = path;
            _current = this;
        }

        public void AddGeneratableItem(IGeneratable item)
        {
            _generatableItems.Add(item);
        }

        public void Dispose()
        {
            Generator.Current.GenerateFile(this);
            _current = null;
        }
    }
}