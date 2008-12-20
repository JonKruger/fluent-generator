namespace FluentGenerator
{
    public interface IGenerator
    {
        ICodeWriter Writer { get; }

        void Generate();
        void GenerateFile(OutputFile file);
    }
}