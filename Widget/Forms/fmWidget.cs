using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using VirusTotal;
using static Widget.WidgetConfiguration;

namespace Widget
{
    public partial class frmWidget : Form
    {
        // Performance
        private readonly PerformanceCounter cpuCounter = new("Processor", "% Processor Time", "_Total");
        private readonly PerformanceCounter ramCounter = new("Memory", "Available MBytes");

        // Widget settings
        WidgetSettings widgetSettings = new();


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
            widgetSettings = widgetSettings.LoadSettingsFromConfigFile();
        }

        private void frmWidget_Load(object sender, EventArgs e)
        {
            int distanceFromEdge = 10;
            int formX = Screen.PrimaryScreen.Bounds.Width - Width - distanceFromEdge;
            int formY = distanceFromEdge;
            Location = new System.Drawing.Point(formX, formY);

            getCurrentSystemUsage();
        }

        private void frmWidget_MouseDown(object sender, MouseEventArgs e)
        {

            WindowsAPI.DragWindowsForm(this.Handle);

        }

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


        private async Task<ResponseParser.VTReport> GetNonQueuedReportAsync(VT vt, string reportId, int delay = 10)
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



        /* Widget display system resource usage */
        private async void getCurrentSystemUsage()
        {
            float cpuUsage;
            int cpuUsageInt;

            //Get installed ram
            WindowsAPI.GetPhysicallyInstalledSystemMemory(out long memKb);

            memKb = memKb / 1024;

            await Task.Run(() =>
            {
                // ToDo  CancellationToken
                for (; ; )
                {
                    cpuUsage = cpuCounter.NextValue();
                    cpuUsageInt = Convert.ToInt32(cpuUsage);
                    Invoke(new Action(() => pbCPU.Value = cpuUsageInt));


                    float ramUsage = ramCounter.NextValue();
                    float ramPercentage = (ramUsage / memKb) * 100;
                    int ramPercentageInt = (int)Math.Round(ramPercentage);
                    Invoke(new Action(() => pbRAM.Value = ramPercentageInt));

                    Thread.Sleep(1000);
                }
            });
        }
    }
}