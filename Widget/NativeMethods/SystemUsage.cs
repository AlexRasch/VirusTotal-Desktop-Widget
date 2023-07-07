using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Widget
{
    /* Functions to help the widget display system usage */

    public static partial class WindowsAPI
    {
        public static float GetMemoryUsage()
        {
            NativeMethods.PERFORMANCE_INFORMATION performanceInfo = new NativeMethods.PERFORMANCE_INFORMATION();
            performanceInfo.cb = (uint)Marshal.SizeOf(performanceInfo);

            // Retrieve performance information
            if (NativeMethods.GetPerformanceInfo(out performanceInfo, performanceInfo.cb))
            {
                long totalPhysicalMemory = performanceInfo.PhysicalTotal * performanceInfo.PageSize;
                long availablePhysicalMemory = performanceInfo.PhysicalAvailable * performanceInfo.PageSize;

                // Prevent division by 0 in rare case
                if (totalPhysicalMemory > 0)
                {
                    float memoryUsage = 100f - ((float)availablePhysicalMemory / totalPhysicalMemory) * 100f;
                    return memoryUsage;
                }
            }

            return 0;
        }


        internal static partial class NativeMethods
        {

        }

    }
}
