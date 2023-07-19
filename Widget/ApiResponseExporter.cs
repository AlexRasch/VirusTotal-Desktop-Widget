using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget
{
    public class ApiResponseExporter
    {
        /// <summary>
        ///  Contains the RAW response from VirusTotal
        /// </summary>
        public string ApiResponseRaw { get; set; }

        /// <summary>
        ///  The directory where the API response will be exported as a file
        /// </summary>
        //public string ExportDirectory { get; set; }

        /// <summary>
        ///  Filename of the exported respons
        /// </summary>
        //public string ExportFileName { get; set; }

        /// <summary>
        ///  The full path where the file will be exported to
        /// </summary>
        public string ExportFullPath { get; set; }

        /// <summary>
        /// Takes the raw API response, the export directory and the export file name as parameters
        /// </summary>
        /// <param name="apiResponseRaw"></param>
        /// <param name="exportDirectory"></param>
        /// <param name="exportFileName"></param>
        public ApiResponseExporter(string apiResponseRaw, string exportFullPath)
        {
            ValidatePath(exportFullPath);

            ApiResponseRaw = apiResponseRaw;
            ExportFullPath = exportFullPath;
        }

        /// <summary>
        ///  Saves a file
        /// </summary>
        /// <returns></returns>
        public bool SaveFile()
        {
            try
            {
                File.WriteAllText(ExportFullPath, ApiResponseRaw);

                if(File.Exists(ExportFullPath))
                    return true;
                return false;
            }
            catch {
                return false;
            }
        }

        /// <summary>
        ///  Validates a path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ValidatePath(string path)
        {
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                return true;
            }
            catch (System.IO.PathTooLongException) {
                return false;
            }
            catch {
            
            }
            return false;
        }

    }
}
