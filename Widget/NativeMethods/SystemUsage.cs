using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Widget
{
    /* Functions to help the widget display system usage */

    public static partial class WindowsAPI
    {
        /// <summary>
        /// Retrieves the memory usage percentage.
        /// </summary>
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

        /// <summary>
        /// Retrieves the CPU usage percentage
        /// </summary>
        public static float GetCpuUsage()
        {
            NativeMethods.FILETIME idleTime, kernelTime, userTime;
            if (!NativeMethods.GetSystemTimes(out idleTime, out kernelTime, out userTime))
            {
                // Failed to retrieve system times
                throw new InvalidOperationException("Failed to retrieve system times.");
            }

            ulong idleTime64 = ((ulong)idleTime.dwHighDateTime << 32) | idleTime.dwLowDateTime;
            ulong kernelTime64 = ((ulong)kernelTime.dwHighDateTime << 32) | kernelTime.dwLowDateTime;
            ulong userTime64 = ((ulong)userTime.dwHighDateTime << 32) | userTime.dwLowDateTime;

            ulong systemTime64 = kernelTime64 + userTime64;
            ulong totalTime64 = systemTime64 + idleTime64;

            if (totalTime64 == 0)
            {
                // Prevent division by zero
                return 0f;
            }

            float cpuUsage = (float)((systemTime64 - idleTime64) * 100) / totalTime64;
            return cpuUsage;
        }

        internal static partial class NativeMethods
        {

        }

    }
}
