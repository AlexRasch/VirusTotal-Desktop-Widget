using System;
using System.Collections.Generic;
using System.IO;
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
        public string FileContent { get; set; }

        /// <summary>
        /// The full path of the file for writing or reading.
        /// </summary>
        public string FileFullPath { get; set; }

        /// <summary>
        /// Gets a value indicating whether an error occurred during the operation.
        /// </summary>
        public bool HasError { get; private set; } = false;

        /// <summary>
        ///  Gets the value of the error message.
        /// </summary>
        public string ErrorMessage { get; private set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the FileIOManager class with the file content and file path.
        /// </summary>
        /// <param name="fileContent">The content of the file to be saved or read.</param>
        /// <param name="fileFullPath">The full path of the file for writing or reading.</param>
        public FileIOManager(string fileContent, string fileFullPath)
        {

            FileContent = fileContent;
            FileFullPath = fileFullPath;

        }


        public FileIOManager(string fileFullPath)
        {
            FileFullPath = fileFullPath;
        }

        /// <summary>
        /// Saves the file content to the specified file.
        /// </summary>
        /// <returns>True if the file was successfully saved, false otherwise.</returns>
        public bool WriteFile()
        {

            if (!ValidatePath(FileFullPath))
                return false;

            try
            {
                File.WriteAllText(FileFullPath, FileContent);
                return File.Exists(FileFullPath);

            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Reads the content of the specified file.
        /// </summary>
        /// <returns>The content of the file as a string, or null if an error occurred.</returns>
        public bool ReadFile(out string fileContent)
        {
            if (!ValidatePath(FileFullPath))
            {
                fileContent = string.Empty;
                return false;
            }
            try
            {
                fileContent = File.ReadAllText(FileFullPath);
                return true;
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                fileContent = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Validates the provided file path and checks if it's a valid path.
        /// </summary>
        /// <param name="filePath">The file path to validate.</param>
        /// <returns>True if the file path is valid, false otherwise.</returns>
        public bool ValidatePath(string path)
        {
            if (path.Length >= 260)
            {
                OnError("Path to long");
                throw new PathTooLongException();
            }
            if (!path.Contains('.'))
            {
                OnError("Invalid path");
                throw new Exception("The path is not valid");
            }
                
            return true;
        }

        private void OnError(string errorMessage)
        {
            HasError = true;
            ErrorMessage = errorMessage;
        }
    }
}
