using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget
{
    public partial class frmWidget : Form
    {
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Cancle the getCurrentSystemUsage
        /// </summary>
        private void CancelSystemUsage()
        {
            cancellationTokenSource?.Cancel();
        }

        /// <summary>
        /// Retrieves the current system usage, including CPU and RAM usage, and updates the corresponding UI controls.
        /// </summary>
        private async void GetCurrentSystemUsage()
        {
            cancellationTokenSource = new();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            await Task.Run(() =>
            {
                using PerformanceCounter cpuCounter = new("Processor", "% Processor Time", "_Total");
                using PerformanceCounter ramCounter = new("Memory", "Available MBytes");

                // Get installed RAM
                WindowsAPI.GetPhysicallyInstalledSystemMemory(out long memKb);

                const float usageThreshold = 2.0f;

                float cpuUsage;
                float previousCpuUsage = 0f;
                int cpuUsageInt;

                float ramUsage;
                float previousRamUsage = 0f;
                int ramPercentageInt;

                while (!cancellationToken.IsCancellationRequested)
                {
                    cpuUsage = cpuCounter.NextValue();
                    cpuUsageInt = (int)Math.Round(cpuUsage);

                    ramUsage = ramCounter.NextValue();
                    ramPercentageInt = (int)Math.Min(ramUsage * 100 / memKb, 100);


                    if (Math.Abs(cpuUsage - previousCpuUsage) > usageThreshold || Math.Abs(ramUsage - previousRamUsage) > usageThreshold)
                    {
                        Invoke(new Action(() =>
                        {
                            pbCPU.Value = cpuUsageInt;
                            pbRAM.Value = ramPercentageInt;
                        }));
                        previousCpuUsage = cpuUsage;
                        previousRamUsage = ramUsage;
                    }

                    Thread.Sleep(1000);
                }
            }, cancellationToken);
        }
    }
}
