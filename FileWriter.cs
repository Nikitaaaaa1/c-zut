using System;
using System.IO;
using System.Text;

namespace laba1
{
    public class FileWriter : IDisposable
    {
        private bool overrideFile = false;
        private FileStream fileStream;

        public FileWriter(string filename)
        {
            if (File.Exists(filename))
            {
                fileStream = overrideFile ? File.Create(filename) : new FileStream(filename, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fileStream = File.Create(filename); 
            }
        }

        public void SetOverrideMode(bool overrideFile)
        {
            this.overrideFile = overrideFile;
        }

        public void AddText(string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            
            fileStream.Write(info, 0, info.Length); 
        }

        public void Close() => fileStream.Close();

        public void Dispose() => Close();
    }
}