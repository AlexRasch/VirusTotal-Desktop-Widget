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

        // ScanResult Form
        public const string FileSizeLabel = "File size:";

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
