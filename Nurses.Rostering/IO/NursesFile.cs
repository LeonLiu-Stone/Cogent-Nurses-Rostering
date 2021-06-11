# pragma warning disable 1591

using System;
using System.IO;

namespace Nurses.Rostering.IO
{
    public class NursesFile : INursesFile
    {
        private FileInfo _fileInfo;

        public NursesFile(string fileName)
        {
            _fileInfo = new FileInfo(fileName);
        }

        public string FullName
        { 
            get { return _fileInfo.FullName; } 
        }

        public StreamReader OpenText()
        {
            return  _fileInfo.OpenText();
        }
    }

    public interface INursesFile
    {
        string FullName { get; }
        StreamReader OpenText();
    }
}