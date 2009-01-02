using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Generators;

namespace FluentGenerator
{
    public class GeneratorFactory : IGeneratorFactory
    {
        private Type _classGeneratorType;
        private Type _namespaceGeneratorType;
        private Type _propertyGeneratorType;
        private Type _fieldGeneratorType;
        private Type _methodGeneratorType;

        public void ClassGeneratorTypeIs<T>() where T : class, IClassGenerator
        {
            _classGeneratorType = typeof(T);
        }

        public void NamespaceGeneratorTypeIs<T>() where T : class, INamespaceGenerator
        {
            _namespaceGeneratorType = typeof(T);
        }

        public void PropertyGeneratorTypeIs<T>() where T : class, IPropertyGenerator
        {
            _propertyGeneratorType = typeof(T);
        }

        public void FieldGeneratorTypeIs<T>() where T : class, IFieldGenerator
        {
            _fieldGeneratorType = typeof(T);
        }

        public void MethodGeneratorTypeIs<T>() where T : class, IMethodGenerator
        {
            _methodGeneratorType = typeof(T);
        }

        public IClassGenerator CreateClassGenerator()
        {
            return (IClassGenerator) CreateGenerator(_classGeneratorType);
        }

        public INamespaceGenerator CreateNamespaceGenerator()
        {
            return (INamespaceGenerator)CreateGenerator(_namespaceGeneratorType);
        }

        public IPropertyGenerator CreatePropertyGenerator()
        {
            return (IPropertyGenerator)CreateGenerator(_propertyGeneratorType);
        }

        public IFieldGenerator CreateFieldGenerator()
        {
            return (IFieldGenerator)CreateGenerator(_fieldGeneratorType);
        }

        public IMethodGenerator CreateMethodGenerator()
        {
            return (IMethodGenerator)CreateGenerator(_methodGeneratorType);
        }

        private IGeneratable CreateGenerator(Type type)
        {
            if (type == null)
                throw new GenerationException("Cannot create generator because type was not specified.");

            return (IGeneratable)Activator.CreateInstance(type);
        }
    }
}
