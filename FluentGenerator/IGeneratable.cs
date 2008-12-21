namespace FluentGenerator
{
    public interface IGeneratable
    {
        void Generate(ICodeWriter codeWriter);
    }
}