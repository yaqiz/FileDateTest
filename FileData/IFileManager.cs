using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
   public interface IFileManager
    {
        bool ValidArguments(string[] args, ref string errorDesc);
        string GetFileVersion(string para, string filePath);
        string  GetFileSize(string para, string filePath);
    }
}
