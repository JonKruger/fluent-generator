using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FluentGenerator.Service
{
    public class FileSystemService : IFileSystemService
    {
        public void WriteToFile(string path, string data)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(data);
                writer.Flush();
                writer.Close();
            }
        }

        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            File.Copy(sourceFileName, destFileName, overwrite);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDiretory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
