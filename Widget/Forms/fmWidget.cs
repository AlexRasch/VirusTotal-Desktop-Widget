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
                FormUtils.FadeInForm(this);
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
            System.Windows.Forms.ToolTip toolTipScan = new();
            toolTipScan.SetToolTip(this.pbSubmit, "Submit File for VirusTotal Analysis");

            System.Windows.Forms.ToolTip toolTipSettingsWidget = new();
            toolTipSettingsWidget.SetToolTip(this.btnSettings, "View and edit settings");

            System.Windows.Forms.ToolTip toolTipExitWidget = new();
            toolTipExitWidget.SetToolTip(this.lblExit, "Shutdown the widget");

            GetCurrentSystemUsage();
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
                await FormUtils.FadeOutForm(this);

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
                VT vt = new(widgetSettings.VirusTotalApiKey);

                // Toaster
                ToasterForm toaster = new(Constants.SubmittingFileTitle, Constants.SubmittingFileMessage, 3000, widgetSettings.FadeEffect);
                toaster.Show();

                // Scan file
                ResponseParser vtReponse = new();
                vtReponse = await vt.ScanFileAsync(vt, openFileDialog.FileName);
                
                // Handle API error
                if (vtReponse.ErrorCode != null)
                {
                    MessageBox.Show($"Error:{vtReponse.ErrorCode.Code}", "API issues");
                    return;
                }
#if DEBUG
                Debug.WriteLine($"Submited file for analyis");
#endif
                // Display report
                fmVTScanResult scanResult = new(vtReponse);
                scanResult.Show();
                // Dispose
                vt.Dispose();
            }

        }
        //private void pbScan_DragDrop(object sender, DragEventArgs? e)
        //{
        //    if (e?.Data.GetDataPresent(DataFormats.FileDrop) == true)
        //    {
        //        string[]? filePaths = e.Data.GetData(DataFormats.FileDrop) as string[];
        //        if (filePaths != null && filePaths.Length > 0)
        //        {
        //            MessageBox.Show(filePaths[0], "File");
        //        }
        //    }
        //}

        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Cancle the getCurrentSystemUsage
        /// </summary>
        private void CancelSystemUsage() => cancellationTokenSource?.Cancel();

        /// <summary>
        /// Retrieves the current system usage, including CPU and RAM usage, and updates the corresponding UI controls.
        /// </summary>
        private async void GetCurrentSystemUsage()
        {
            
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            await Task.Run(() =>
            {
                const float usageThreshold = 2.0f;

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
                    Thread.Sleep(1000);
                    //Task.Delay(2000);
                }
            }, cancellationToken);
        }


    }
}