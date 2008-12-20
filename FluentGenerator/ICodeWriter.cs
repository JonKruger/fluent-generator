namespace FluentGenerator
{
    public interface ICodeWriter
    {
        CodeWriter AppendLine(string s, params object[] args);
        void IncreaseIndent();
        void DecreaseIndent();
    }
}