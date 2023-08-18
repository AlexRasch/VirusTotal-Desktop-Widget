using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using VirusTotal;
using static Widget.WidgetConfiguration;
using System.Threading;
using System.ComponentModel;
using Widget.Forms;

namespace Widget
{
#pragma warning disable IDE1006
    public partial class frmWidget : Form
    {
        // Widget settings
        WidgetSettings widgetSettings = new();

        public frmWidget()
        {
            InitializeComponent();
            // Load Widget settings
            widgetSettings = WidgetSettings.LoadSettingsFromConfigFile();
            cancellationTokenSource = new();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (widgetSettings.FadeEffect)
                _ = FormUtils.FadeInForm(this.Handle);
        }
        private void frmWidget_Load(object sender, EventArgs e)
        {
            int distanceFromEdge = 10;
            int formX = Screen.PrimaryScreen.Bounds.Width - Width - distanceFromEdge;
            int formY = distanceFromEdge;
            Location = new System.Drawing.Point(formX, formY);

            this.MinimumSize = new Size(Width, Height);
            this.MaximumSize = this.MinimumSize;

            // UX
            System.Windows.Forms.ToolTip toolTipImportReport = new();
            toolTipImportReport.SetToolTip(this.pbImportReport, "Import and view a VirusTotal analysis");

            System.Windows.Forms.ToolTip toolTipScan = new();
            toolTipScan.SetToolTip(this.pbSubmit, "Submit File for VirusTotal Analysis");

            System.Windows.Forms.ToolTip toolTipSettingsWidget = new();
            toolTipSettingsWidget.SetToolTip(this.btnSettings, "View and edit settings");

            System.Windows.Forms.ToolTip toolTipExitWidget = new();
            toolTipExitWidget.SetToolTip(this.lblExit, "Shutdown the widget");

            GetCurrentSystemUsage(widgetSettings.SystemUsageUpdateInterval, widgetSettings.SystemUsageThreshold, widgetSettings.OptimizePerformance);
        }
        private void lblExit_MouseEnter(object sender, EventArgs e) => lblExit.BackColor = Color.DimGray;
        private void lblExit_MouseLeave(object sender, EventArgs e) => lblExit.BackColor = Color.Transparent;

        /* Widget  */
        private async void lblExit_Click(object sender, EventArgs e)
        {
            // Cancel running tasks
            try
            {
                CancelSystemUsage();
            }
            catch { }
            cancellationTokenSource?.Cancel();
            cancellationTokenSource?.Dispose();

            if (widgetSettings.FadeEffect)
                await FormUtils.FadeOutForm(Handle);

            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (fmSettings fmSettings = new())
            {
                fmSettings.ShowDialog();
            }
            //Reload settings
            widgetSettings = WidgetSettings.LoadSettingsFromConfigFile();
        }
        /* VirusTotal */
        private void pbImportReport_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Title = Constants.OpenFileDialogTitle;
            openFileDialog.Filter = "JSON|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
#if DEBUG
                Debug.WriteLine($"Showing fmVTScanResult");
#endif
                fmVTScanResult scanResult = new(openFileDialog.FileName, widgetSettings.FadeEffect);
                scanResult.Show();
            }
        }

        private async void pbSubmit_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            // Check if we have a key
            if (string.IsNullOrEmpty(widgetSettings.VirusTotalApiKey))
            {
                MessageBox.Show("Missing VirusTotal API key", "Error");
                return;
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

#if DEBUG
                Debug.WriteLine($"Showing fmVTScanResult");
#endif
                fmVTScanResult scanResult = new(openFileDialog.FileName, widgetSettings.VirusTotalApiKey, widgetSettings.FadeEffect);
                scanResult.Show();
            }

        }
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Cancle the getCurrentSystemUsage
        /// </summary>
        private void CancelSystemUsage() => cancellationTokenSource?.Cancel();

        /// <summary>
        /// Retrieves the current system usage, including CPU and RAM usage, and updates the corresponding UI controls.
        /// </summary>
        private async void GetCurrentSystemUsage(int updateInterval, int systemUsageThreshold, bool optimizePerformance)
        {
            if (updateInterval == 0 || systemUsageThreshold == 0)
                throw new Exception("Settings for SystemUsage invalid");

            float usageThreshold = (float)systemUsageThreshold;
            updateInterval = updateInterval * 1000;

            CancellationToken cancellationToken = cancellationTokenSource.Token;

            // Optimize performance
            PerformanceOptimizer optimizer = null;

            if (optimizePerformance)
                optimizer = new(updateInterval);


            await Task.Run(async () =>
            {

                float cpuUsage;
                float previousCpuUsage = 0f;

                float ramUsage;
                float previousRamUsage = 0f;

                while (!cancellationToken.IsCancellationRequested)
                {
                    cpuUsage = WindowsAPI.GetCpuUsage();
                    ramUsage = WindowsAPI.GetMemoryUsage();

                    if (Math.Abs(cpuUsage - previousCpuUsage) > usageThreshold || Math.Abs(ramUsage - previousRamUsage) > usageThreshold)
                    {
                        Invoke(new Action(() =>
                        {
                            pbCPU.Value = (int)Math.Min(cpuUsage, 100);
#if DEBUG
                            Debug.WriteLine($"CPU: {pbCPU.Value}");
#endif
                            pbRAM.Value = (int)Math.Min(ramUsage, 100);
#if DEBUG
                            Debug.WriteLine($"Ram: {pbRAM.Value}");
#endif
                        }));
                    }
                    previousCpuUsage = cpuUsage;
                    previousRamUsage = ramUsage;

                    // Optimize performance
                    if (optimizer != null && optimizer.ShouldCheckFullScreenActivity(updateInterval))
                        await optimizer.PerformOptimizationDelay();
                    
                    await Task.Delay(updateInterval);
                }
            }, cancellationToken);
        }



    }
}