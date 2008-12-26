namespace FluentGenerator
{
    public interface IGenerator
    {
        void Generate();
        void GenerateFile(OutputFile file);
        IOpenNamespaceExpression CurrentNamespace { get; set; }
    }
}