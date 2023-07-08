using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Widget
{
    public static partial class WindowsAPI
    {


        internal static partial class NativeMethods
        {
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImport("psapi.dll", SetLastError = true)]
            public static extern bool GetPerformanceInfo(out PERFORMANCE_INFORMATION pPerformanceInformation, uint cb);

            [StructLayout(LayoutKind.Sequential)]
            public struct PERFORMANCE_INFORMATION
            {
                public uint cb;
                public long CommitTotal;
                public long CommitLimit;
                public long CommitPeak;
                public long PhysicalTotal;
                public long PhysicalAvailable;
                public long SystemCache;
                public long KernelTotal;
                public long KernelPaged;
                public long KernelNonPaged;
                public long PageSize;
                public uint HandlesCount;
                public uint ProcessCount;
                public uint ThreadCount;
            }
        }

    }
}
