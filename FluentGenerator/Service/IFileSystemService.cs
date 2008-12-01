namespace FluentGenerator.Service
{
    public interface IFileSystemService
    {
        void WriteToFile(string path, string data);
    }
}