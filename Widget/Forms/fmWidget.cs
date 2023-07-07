using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using VirusTotal;
using static Widget.WidgetConfiguration;
using System.Threading;

namespace Widget
{
#pragma warning disable IDE1006
    public partial class frmWidget : Form
    {
        // Widget settings
        readonly WidgetSettings widgetSettings = new();


        public frmWidget()
        {
            InitializeComponent();

            // GUI styling
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox || control is Label)
                    control.BackColor = Color.Transparent;
            }
            pbSubmit.AllowDrop = true;
            Paint += new PaintEventHandler(set_background);

            // UX
            System.Windows.Forms.ToolTip toolTipScan = new();
            toolTipScan.SetToolTip(this.pbSubmit, "Submit File for VirusTotal Analysis");
            System.Windows.Forms.ToolTip toolTipExitWidget = new();
            toolTipScan.SetToolTip(this.lblExit, "Shutdown the widget");

            this.AllowDrop = true;

            // Load Widget settings
            widgetSettings = WidgetSettings.LoadSettingsFromConfigFile();
        }

        private void frmWidget_Load(object sender, EventArgs e)
        {
            int distanceFromEdge = 10;
            int formX = Screen.PrimaryScreen.Bounds.Width - Width - distanceFromEdge;
            int formY = distanceFromEdge;
            Location = new System.Drawing.Point(formX, formY);

            GetCurrentSystemUsage();
        }

        private void frmWidget_MouseDown(object sender, MouseEventArgs e) => WindowsAPI.DragWindowsForm(this.Handle);

        private void set_background(Object? sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle gradient_rectangle = new(0, 0, Width, Height);
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(32, 33, 35), Color.FromArgb(110, 110, 128), 90f);
            graphics.FillRectangle(b, gradient_rectangle);
        }

        /* Widget  */
        private void lblExit_Click(object sender, EventArgs e)
        {
            // Cancel running tasks
            try
            {
                CancelSystemUsage();
            }
            catch { }

            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        /* Used for scanning system and view possible suspect files */
        private void pbScan_Click_1(object sender, EventArgs e)
        {

        }


        private async void pbSettings_Click(object sender, EventArgs e)
        {
            fmSettings fmSettings = new();
            fmSettings.Show();
        }

        /* VirusTotal */
        private async void pbScan_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new())
            {
                if (string.IsNullOrEmpty(widgetSettings.VirusTotalApiKey))
                {
                    MessageBox.Show("Missing VirusTotal API key", "Error");
#if DEBUG
                    Debug.WriteLine("fmWidget: Missing virustotal api key");
#endif
                    return;
                }


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    VT vt = new(widgetSettings.VirusTotalApiKey);

                    // Scan file
                    ResponseParser vtReponse = new();
                    ResponseParser.VTReport vtScanResponse = vtReponse.ParseReport(await vt.ScanFileAsync(openFileDialog.FileName));
#if DEBUG
                    Debug.WriteLine($"Submited file for analyis");
#endif

                    // Get report
                    ResponseParser.VTReport vtScanReport = await GetNonQueuedReportAsync(vt, vtScanResponse.Id);

#if DEBUG
                    Debug.WriteLine($"Report status:{vtScanReport.Status}");
#endif

                    // Display report
                    fmVTScanResult scanResult = new(vtScanReport);
                    scanResult.Show();

                }
            }
        }

        private void pbScan_DragDrop(object sender, DragEventArgs? e)
        {
            if (e?.Data.GetDataPresent(DataFormats.FileDrop) == true)
            {
                string[]? filePaths = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (filePaths != null && filePaths.Length > 0)
                {
                    MessageBox.Show(filePaths[0], "File");
                }
            }
        }

        private static async Task<ResponseParser.VTReport> GetNonQueuedReportAsync(VT vt, string reportId, int delay = 10)
        {
            ResponseParser.VTReport vtScanReport = await vt.GetReportAsync(reportId);
            while (vtScanReport.Status == "queued")
            {
#if DEBUG
                Debug.WriteLine($"Report status:queued ");
#endif
                await Task.Delay(TimeSpan.FromSeconds(delay));
                vtScanReport = await vt.GetReportAsync(reportId);
            }

            return vtScanReport;
        }

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
                // Get installed RAM
                WindowsAPI.GetPhysicallyInstalledSystemMemory(out long memKb);

                const float usageThreshold = 2.0f;

                float cpuUsage;
                float previousCpuUsage = 0f;
                int cpuUsageInt;

                float ramUsage;
                float previousRamUsage = 0f;
                //int ramPercentageInt;

                while (!cancellationToken.IsCancellationRequested)
                {
                    using PerformanceCounter cpuCounter = new("Processor", "% Processor Time", "_Total");
                    //using PerformanceCounter ramCounter = new("Memory", "Available MBytes");

                    cpuUsage = cpuCounter.NextValue();
                    cpuUsageInt = (int)Math.Round(cpuUsage);

                    //ramUsage = ramCounter.NextValue();
                    ramUsage = WindowsAPI.GetMemoryUsage();
                    //ramPercentageInt = (int)Math.Min(ramUsage * 100 / memKb, 100);

                    if (Math.Abs(cpuUsage - previousCpuUsage) > usageThreshold || Math.Abs(ramUsage - previousRamUsage) > usageThreshold)
                    {
                        Invoke(new Action(() =>
                        {
                            pbCPU.Value = cpuUsageInt;
                            //pbRAM.Value = ramPercentageInt;
                            pbRAM.Value = (int)Math.Min(ramUsage, 100);
                        }));
                    }

                    previousCpuUsage = cpuUsage;
                    previousRamUsage = ramUsage;

                    //Task.Delay(1000); //this appear to increase ram usage with around 10mb D:
                    Thread.Sleep(1000);
                }
            }, cancellationToken);
        }
    }
}