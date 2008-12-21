namespace FluentGenerator
{
    public interface IGenerator
    {
        void Generate();
        void GenerateFile(OutputFile file);
    }
}