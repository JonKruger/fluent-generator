using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGenerator.Generators;
using StructureMap;

namespace FluentGenerator
{
    public class GeneratorFactory : IGeneratorFactory
    {
        private Type _classGeneratorType;
        private Type _namespaceGeneratorType;
        private Type _propertyGeneratorType;
        private Type _fieldGeneratorType;
        private Type _methodGeneratorType;
        private Type _propertyGeneratorCollectionType;
        private Type _fieldGeneratorCollectionType;
        private Type _methodGeneratorCollectionType;

        public GeneratorFactory()
        {
            AssignDefaultClasses();
        }

        public void Reset()
        {
            _classGeneratorType = null;
            _namespaceGeneratorType = null;
            _propertyGeneratorType = null;
            _fieldGeneratorType = null;
            _methodGeneratorType = null;
            _propertyGeneratorCollectionType = null;
            _fieldGeneratorCollectionType = null;
            _methodGeneratorCollectionType = null;
        }

        private void AssignDefaultClasses()
        {
            ClassGeneratorTypeIs<ClassGenerator>();
            NamespaceGeneratorTypeIs<NamespaceGenerator>();
            PropertyGeneratorTypeIs<PropertyGenerator>();
            FieldGeneratorTypeIs<FieldGenerator>();
            MethodGeneratorTypeIs<MethodGenerator>();
            PropertyGeneratorCollectionTypeIs<PropertyGeneratorCollection>();
            FieldGeneratorCollectionTypeIs<FieldGeneratorCollection>();
            MethodGeneratorCollectionTypeIs<MethodGeneratorCollection>();
        }

        public void ClassGeneratorTypeIs<T>() where T : class, IClassGenerator
        {
            _classGeneratorType = typeof (T);
            ObjectFactory.Configure(x => x.ForConcreteType<T>());
        }

        public void NamespaceGeneratorTypeIs<T>() where T : class, INamespaceGenerator
        {
            _namespaceGeneratorType = typeof(T);
            ObjectFactory.Configure(x => x.ForConcreteType<T>());
        }

        public void PropertyGeneratorTypeIs<T>() where T : class, IPropertyGenerator
        {
            _propertyGeneratorType = typeof(T);
            ObjectFactory.Configure(x => x.ForConcreteType<T>());
        }

        public void FieldGeneratorTypeIs<T>() where T : class, IFieldGenerator
        {
            _fieldGeneratorType = typeof(T);
            ObjectFactory.Configure(x => x.ForConcreteType<T>());
        }

        public void MethodGeneratorTypeIs<T>() where T : class, IMethodGenerator
        {
            _methodGeneratorType = typeof(T);
            ObjectFactory.Configure(x => x.ForConcreteType<T>());
        }

        public void PropertyGeneratorCollectionTypeIs<T>() where T : class, IPropertyGeneratorCollection
        {
            _propertyGeneratorCollectionType = typeof(T);
            ObjectFactory.Configure(x => x.ForConcreteType<T>());
        }

        public void FieldGeneratorCollectionTypeIs<T>() where T : class, IFieldGeneratorCollection
        {
            _fieldGeneratorCollectionType = typeof(T);
            ObjectFactory.Configure(x => x.ForConcreteType<T>());
        }

        public void MethodGeneratorCollectionTypeIs<T>() where T : class, IMethodGeneratorCollection
        {
            _methodGeneratorCollectionType = typeof(T);
            ObjectFactory.Configure(x => x.ForConcreteType<T>());
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

        public IPropertyGeneratorCollection CreatePropertyGeneratorCollection()
        {
            return (IPropertyGeneratorCollection)CreateGenerator(_propertyGeneratorCollectionType);
        }

        public IFieldGeneratorCollection CreateFieldGeneratorCollection()
        {
            return (IFieldGeneratorCollection)CreateGenerator(_fieldGeneratorCollectionType);
        }

        public IMethodGeneratorCollection CreateMethodGeneratorCollection()
        {
            return (IMethodGeneratorCollection)CreateGenerator(_methodGeneratorCollectionType);
        }

        private IGeneratable CreateGenerator(Type type)
        {
            if (type == null)
                throw new GenerationException("Cannot create generator because type was not specified.");

            return (IGeneratable)ObjectFactory.GetInstance(type);
        }
    }
}
