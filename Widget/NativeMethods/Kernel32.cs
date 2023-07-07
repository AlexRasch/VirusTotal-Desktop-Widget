using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Widget
{
    public static partial class WindowsAPI
    {

        public static long GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes)
        {
            NativeMethods.GetPhysicallyInstalledSystemMemory(out TotalMemoryInKilobytes);
            return TotalMemoryInKilobytes /= 1024;
        }

        internal static partial class NativeMethods
        {
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImport("kernel32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool GetSystemTimes(out FILETIME lpIdleTime, out FILETIME lpKernelTime, out FILETIME lpUserTime);

            [StructLayout(LayoutKind.Sequential)]
            public struct FILETIME
            {
                public uint dwLowDateTime;
                public uint dwHighDateTime;
            }
        }

    }
}