using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace Widget
{
    /// <summary>
    /// Contains constant values used in the Widget project.
    /// </summary>
    public class Constants
    {
        // VirusTotal project have its own Constants


        // Mutex Messages
        public const string AlreadyRunningMessage = "Widget is already running.\n\n Please close the existing instance before launching a new one.";
        public const string AlreadyRunningMessageTitle = "Widget already running";

        #region Widget Form
        public const string OpenFileDialogTitle = "Import scan response";
        #endregion

        #region ScanResult Form
        
        // GUI
        public const string FileSizeLabel = "File size:";

        // Scanning
        public const string ErrorDuringScan = "An error occurred during the scanning process.";
        public const string ErrorDuringScanTitle = "Scanning error";

        // Parse 
        public const string ParseReportEmpty = "The report appears to be empty.";
        public const string ParseReportEmptyTitle = "Parse issue";


        // Read/Write 
        public const string SaveFileDialogTitle = "Export scan response";
        public const string SaveFileDialogNothingToExport = "There is no scan result to export.";
        public const string SaveFileDialogNothingToExportTitle = "Nothing to Export";
        public const string SaveFileDialogExportError = "An error occurred while exporting the scan results.";
        public const string SaveFileDialogExportErrorTitle = "Export Error";
        
        #endregion

        // Generic
        public const string ReportPathIsEmpty = "Invalid report file path.";
        public const string Error = "Error";

        // Toaster Message & Titles
        public const string SubmittingFileTitle = "Sending file to VirusTotal";
        public const string SubmittingFileMessage = "We are now submitting your file to VirusTotal for scanning...";



        public static string GetApplicationPath()
        {
#if DEBUG
            // In debug mode, use the executing assembly (e.g., MyApp.exe)
            return Assembly.GetExecutingAssembly().Location;
#else
            // In release mode, use the entry assembly (e.g., MyApp.exe)
            string path = Assembly.GetEntryAssembly().Location;
            if (string.IsNullOrEmpty(path))
            {
                // Fallback to Process.GetCurrentProcess().MainModule.FileName
                return Process.GetCurrentProcess().MainModule.FileName;
            }
            return path;
#endif
        }

    }
}
