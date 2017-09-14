using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalParkPortable;

namespace NationalParks.IO
{
    public class FileHandler : NationalParkPortable.IFileHandler
    {
        public FileHandler()
        {
        }

        #region IFileHandler implementation

        public bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        public string ReadAllText(string filename)
        {
            using (StreamReader reader = File.OpenText(filename))
            {
                return reader.ReadToEnd();
            }
        }

        public void WriteAllText(string filename, string content)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                writer.Write(content);
            }
        }

       

        #endregion
    }
}
