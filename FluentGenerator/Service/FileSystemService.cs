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
    }
}
