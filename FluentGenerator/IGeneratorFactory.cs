using FluentGenerator.Generators;

namespace FluentGenerator
{
    public interface IGeneratorFactory
    {
        void ClassGeneratorTypeIs<T>() where T : class, IClassGenerator;
        void NamespaceGeneratorTypeIs<T>() where T : class, INamespaceGenerator;
        void PropertyGeneratorTypeIs<T>() where T : class, IPropertyGenerator;
        void FieldGeneratorTypeIs<T>() where T : class, IFieldGenerator;
        void MethodGeneratorTypeIs<T>() where T : class, IMethodGenerator;

        IClassGenerator CreateClassGenerator();
        INamespaceGenerator CreateNamespaceGenerator();
        IPropertyGenerator CreatePropertyGenerator();
        IFieldGenerator CreateFieldGenerator();
        IMethodGenerator CreateMethodGenerator();
    }
}