using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget
{
    /// <summary>
    /// Handles file input and output operations, providing methods to read and write files.
    /// </summary>
    public class FileIOManager
    {
        /// <summary>
        /// Contains the content of the file to be saved or read.
        /// </summary>
        public string FileContent  { get; set; }

        /// <summary>
        /// The full path of the file for writing or reading.
        /// </summary>
        public string FileFullPath { get; set; }

        /// <summary>
        /// Gets a value indicating whether an error occurred during the operation.
        /// </summary>
        public bool HasError { get; private set; }

        /// <summary>
        ///  Gets the value of the error message.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the FileIOManager class with the file content and file path.
        /// </summary>
        /// <param name="fileContent">The content of the file to be saved or read.</param>
        /// <param name="fileFullPath">The full path of the file for writing or reading.</param>
        public FileIOManager(string fileContent, string fileFullPath)
        {
            ValidatePath(fileFullPath);

            FileContent  = fileContent;
            FileFullPath = fileFullPath;

            HasError = false;
        }

        /// <summary>
        /// Saves the file content to the specified file.
        /// </summary>
        /// <returns>True if the file was successfully saved, false otherwise.</returns>
        public bool WriteFile()
        {
            try
            {
                File.WriteAllText(FileFullPath, FileContent );

                return File.Exists(FileFullPath);
   
            }
            catch (Exception ex) {
                OnError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Reads the content of the specified file.
        /// </summary>
        /// <returns>The content of the file as a string, or null if an error occurred.</returns>
        public string ReadFile()
        {
            throw new NotImplementedException();
            //return null;
        }

        /// <summary>
        /// Validates the provided file path and checks if it's a valid path.
        /// </summary>
        /// <param name="filePath">The file path to validate.</param>
        /// <returns>True if the file path is valid, false otherwise.</returns>
        public bool ValidatePath(string path)
        {
            try
            {
                System.IO.FileInfo fileInfo = new (path);
                return true;
            }
            catch (System.IO.PathTooLongException ex) {
                OnError($"ValidatePat PathTooLong:{ex.Message}");
            }
            catch(Exception ex) {
                OnError($"ValidatePath:{ex.Message}");
            }
            return false;
        }

        private void OnError(string errorMessage)
        {
            HasError = true;
            ErrorMessage = errorMessage;
        }
    }
}
