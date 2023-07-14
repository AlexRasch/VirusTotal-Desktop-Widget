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
#if DEBUG
        // In debug mode, use the executing assembly (e.g., MyApp.exe)
        public static string ApplicationPath = Assembly.GetExecutingAssembly().Location;
#else
        // In release mode, use the entry assembly (e.g., MyApp.exe)
        public static string ApplicationPath = Assembly.GetEntryAssembly().Location;
#endif

    }
}
