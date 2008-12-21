namespace FluentGenerator
{
    public interface ICodeWriter
    {
        ICodeWriter Append(string s);
        ICodeWriter AppendLine();
        ICodeWriter AppendLine(string s);
        ICodeWriter AppendLineFormat(string s, params object[] args);
        void IncreaseIndent();
        void DecreaseIndent();
        int Length { get; }
    }
}