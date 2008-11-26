using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FluentGenerator
{
    public class OutputFile : IDisposable
    {
        private static OutputFile _current;
        private List<ClassData> _classes = new List<ClassData>();

        public static OutputFile Current
        {
            get { return _current; }
        }

        public ReadOnlyCollection<ClassData> Classes
        {
            get { return _classes.AsReadOnly(); }
        }

        public string Path { get; private set; }

        public OutputFile(string path)
        {
            Path = path;
        }

        public void AddClass(ClassData classData)
        {
            _classes.Add(classData);
        }

        public void Dispose()
        {
            Generator.Current.GenerateFile(this);
        }
    }
}