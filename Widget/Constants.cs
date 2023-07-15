using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace Widget
{
    public class Constants
    {
        public const string AlreadyRunningMessage = "Widget is already running.\n\n Please close the existing instance before launching a new one.";
        public const string AlreadyRunningMessageTitle = "Widget already running";


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
