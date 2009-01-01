namespace FluentGenerator.Generators
{
    public interface IPropertyGenerator : IGeneratable
    {
        string Type { get; set; }
        string Name { get; set; }
        IFieldGenerator ExtractBackingFieldExpression();
        void GeneratePropertyOnly(ICodeWriter codeWriter);
    }
}