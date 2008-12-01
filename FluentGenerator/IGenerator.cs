namespace FluentGenerator
{
    public interface IGenerator
    {
        void Generate(IGenerationOptions options);
        void GenerateFile(OutputFile file);
    }
}