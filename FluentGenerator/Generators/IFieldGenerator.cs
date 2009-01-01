namespace FluentGenerator.Generators
{
    public interface IFieldGenerator : IGeneratable
    {
        string Name { get; set; }
        string Type { get; set; }
    }
}