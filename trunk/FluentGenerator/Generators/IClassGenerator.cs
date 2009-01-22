namespace FluentGenerator.Generators
{
    public interface IClassGenerator : IGeneratable
    {
        string Name { get; set; }
        IFieldGeneratorCollection Fields { get; }
        IPropertyGeneratorCollection Properties { get; }
        IMethodGeneratorCollection Methods { get; }
    }
}