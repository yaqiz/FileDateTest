using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileData;

namespace FileDate.Test
{
    [TestClass]
    public class FileDateTest
    {
        [TestMethod]
        public void FileManager_ValidArguments()
        {
            string[] args = { "-v","-s","c:/test.txt","trigger exception"};
            IFileManager fileManager=new FileManager("–v,--v,/v,--version,","–s, --s, /s, --size,");
            string errorDesc = string.Empty;
            bool actual= fileManager.ValidArguments(args, ref errorDesc);
            Assert.AreEqual(false,actual);
        }

        [TestMethod]
        public void FileManager_GetFileVersion_Failed()
        {
            string validVersion = "–v,--v,/v,--version,";
            string validSize = "–s, --s, /s, --size,";
            IFileManager fileManager=new FileManager(validVersion,validSize);
            string para1 = "trigger exception";
            string actual= fileManager.GetFileVersion(para1, "c:/test.txt");
            string expected = "Invalid parameter. Paramemter shoul be one from the list " + validVersion.Substring(0,validVersion.Length-1);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void FileManager_GetFileVersion_Valid()
        {
            string validVersion = "–v,--v,/v,--version,";
            string validSize = "–s, --s, /s, --size,";
            IFileManager fileManager=new FileManager(validVersion,validSize);
            string failedMsg = "Invalid parameter. Paramemter shoul be one from the list " + validVersion.Substring(0,validVersion.Length-1);
            string[] arrValidVersion = {"–v", "--v", "/v", "--version"};
            int actual = 0;
            foreach (var para in arrValidVersion)
            {
                if (failedMsg != fileManager.GetFileVersion(para, "c:/test.txt"))
                {
                    actual++;
                }
            }

            int expected = arrValidVersion.Length;
            Assert.AreEqual(expected,actual);
        }


        [TestMethod]
        public void FileManager_GetFileSize_Failed()
        {
            string validVersion = "–v,--v,/v,--version,";
            string validSize = "–s, --s, /s, --size,";
            IFileManager fileManager=new FileManager(validVersion,validSize);
            string para1 = "trigger exception";
            string actual= fileManager.GetFileSize(para1, "c:/test.txt");
            string expected = "Invalid parameter. Paramemter shoul be one from the list " + validSize.Substring(0,validSize.Length-1);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void FileManager_GetFileSize_Valid()
        {
            string[] args = { "-v","-s","c:/test.txt","trigger invalid"};
            string validVersion = "–v,--v,/v,--version,";
            string validSize = "–s, --s, /s, --size,";
            IFileManager fileManager=new FileManager(validVersion,validSize);
            string failedMsg = "Invalid parameter. Paramemter shoul be one from the list " + validSize.Substring(0,validSize.Length-1);
            string[] arrValidVersion = {"–s", "--s", "/s", "--size"};
            int actual = 0;
            foreach (var para in arrValidVersion)
            {
                if (failedMsg != fileManager.GetFileSize(para, "c:/test.txt"))
                {
                    actual++;
                }
            }

            int expected = arrValidVersion.Length;
            Assert.AreEqual(expected,actual);
        }
    }
}
