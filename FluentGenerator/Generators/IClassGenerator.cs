namespace FluentGenerator.Generators
{
    public interface IClassGenerator : IGeneratable
    {
        string Name { get; set; }
        FieldGeneratorCollection Fields { get; }
        PropertyGeneratorCollection Properties { get; }
        MethodGeneratorCollection Methods { get; }
    }
}