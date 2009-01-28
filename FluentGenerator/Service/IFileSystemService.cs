namespace FluentGenerator.Service
{
    public interface IFileSystemService
    {
        void WriteToFile(string path, string data);
        void Copy(string sourceFileName, string destFileName, bool overwrite);
        bool Exists(string path);
        bool DirectoryExists(string path);
        void CreateDiretory(string path);
    }
}