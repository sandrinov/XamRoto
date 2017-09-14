using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalParkPortable
{
    public interface IFileHandler
    {
        bool FileExists(string filename);
        string ReadAllText(string filename);
        void WriteAllText(string filename, string content);
    }
}
