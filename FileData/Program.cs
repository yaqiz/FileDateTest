using System;
using System.Collections.Generic;
using System.Linq;

using System.Configuration;
namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //Using Interface so we can swap out using 3rd party method to calculate 
                //Put valid list in config so it is easier to modify and update
                IFileManager fManager=new FileManager(ConfigurationManager.AppSettings["validVersionPara"],ConfigurationManager.AppSettings["validSizePara"]);
                string errorDesc=string.Empty;
                if (fManager.ValidArguments(args,ref errorDesc))
                {
                    string fileVersion = fManager.GetFileVersion(args[0], args[2]);
                    string fileSize = fManager.GetFileSize(args[1], args[2]);
                    Console.WriteLine("File version" + fileVersion);
                    Console.WriteLine("File Size" + fileSize);
                }
                else
                {
                    Console.WriteLine("Invalid Arguments:" + errorDesc);
                }

            }catch (Exception e)
            {
                //Log error with stack trace
                throw e;
            }
            
        }
    }
}
