using System;
using System.Linq;

namespace FilesPreviewGenerator
{
    public class FileInfo
    {
        public FileInfo(string path, string name, string documentFormat)
        {
            this.Path = path;
            this.Name = name;
            this.DocumentFormat = documentFormat;
        }
        public string Path { get; set; }
        public string Name { get; set; }
        public string DocumentFormat { get; set; }
    }
}
