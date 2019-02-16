using System;
using System.Configuration;
using ThirdPartyTools;

namespace FileData
{
    public class FileManager: IFileManager
    {
        private string _validVersionPara;
        private string _validSizePara;
        private FileDetails _fileDetail;
        public  FileManager(string validVersionPara,string validSizePara )
        {

            _validVersionPara = validVersionPara;
            _validSizePara = validSizePara;
            _fileDetail = new FileDetails();
        }

        #region Public
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">Expect 3 arugs: -v, -s, filepath</param>
        /// <param name="errorDesc">error description</param>
        /// <returns></returns>
        public bool ValidArguments(string[] args, ref string errorDesc)
        {
            if (args.Length != 3)
            {
                errorDesc = "Wrong arguments count";
                return false;
            }
            //file path validation, file exist checking...
            
            return true;
        }

         /// <summary>
        /// Get File Version
        /// </summary>
        /// <param name="para">Valid parameter in list –v,--v,/v,--version</param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string  GetFileVersion(string para,string filePath)
        {
            if (_validVersionPara.Contains(para + ","))
            {
                return _fileDetail.Version(filePath);
            }
            else
            {
                return "Invalid parameter. Paramemter shoul be one from the list " + _validVersionPara.Substring(0,_validVersionPara.Length-1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="para"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetFileSize(string para,string filePath)
        {
            if (_validSizePara.Contains(para + ","))
            {
                //Could format the display to Gb, Mb
                return ConvertFileSize(_fileDetail.Size(filePath));
            }
            else
            {
                return "Invalid parameter. Paramemter shoul be one from the list " + _validSizePara.Substring(0,_validSizePara.Length-1);
            }
        }       

        #endregion


        #region Private

        private string ConvertFileSize(int fileSize)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = (double) fileSize;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1) {
                order++;
                len = len/1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string result = String.Format("{0:0.#}{1}", len, sizes[order]);
            return result;
        }

        #endregion
         

    }
}
