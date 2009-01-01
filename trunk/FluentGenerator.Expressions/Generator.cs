using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentGenerator.Expressions
{
    public class Generator : GeneratorBase
    {
        private NamespaceExpression _currentNamespace;

        public ClassExpression CreateClass()
        {
            return CreateClass(null);
        }

        public ClassExpression CreateClass(string className)
        {
            ClassExpression classData = new ClassExpression();
            if (_currentNamespace != null)
                _currentNamespace.AddGeneratableItem(classData.Generator);
            else
                OutputFile.Current.AddGeneratableItem(classData.Generator);

            if (!string.IsNullOrEmpty(className))
                classData.Generator.Name = className;
            return classData;
        }

        public void Namespace(string name)
        {
            _currentNamespace = new NamespaceExpression();
            _currentNamespace.Generator.Name = name;
            OutputFile.Current.AddGeneratableItem(_currentNamespace.Generator);
        }

    }
}
