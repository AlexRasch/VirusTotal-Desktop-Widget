using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirusTotal;
using Widget.Forms;

namespace Widget
{
#pragma warning disable IDE1006
    public partial class fmVTScanResult : Form
    {
        /// <summary>
        /// Gets or sets the report from VirusTotal to display.
        /// </summary>
        private ResponseParser? Report { get; set; }
        /// <summary>
        /// Gets or sets the VirusTotal API key used for scanning.
        /// </summary>
        private string VirusTotalAPIKey { get; set; }
        /// <summary>
        /// Gets or sets the file path to scan.
        /// </summary>
        private string? FileToScanPath { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the fade effect is enabled.
        /// </summary>
        private bool FadeEffect { get; set; }
        /// <summary>
        /// Keeps track of the number of dots to display in the 'Scanning...' text in UpdateTitleStatus method.
        /// </summary>
        private int dotCount = 0;

        /// <summary>
        ///  Used when we have a report from virustotal to display
        /// </summary>
        /// <param name="report"></param>
        public fmVTScanResult(ResponseParser report, bool fadeEffect = false)
        {
            InitializeComponent();
            this.Report = report;
            FadeEffect = fadeEffect;
        }

        /// <summary>
        /// When we want to submit a file
        /// </summary>
        /// <param name="filePath">Path to the file we want to scan</param>
        public fmVTScanResult(string filePath, string virusTotalAPIKey, bool fadeEffect = false)
        {
            this.FileToScanPath = filePath;
            this.VirusTotalAPIKey = virusTotalAPIKey;

            FadeEffect = fadeEffect;

            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (FadeEffect)
                FormUtils.FadeInForm(Handle, 256);
        }
        private async void fmVTScanResult_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(Width, Height);
            this.MaximumSize = this.MinimumSize;

            // Parse report
            if (Report != null)
                await ParseReport(Report);

            // Scan file
            if (!string.IsNullOrEmpty(FileToScanPath))
                await ScanFileAsync();
        }
        private async void btnClose_Click(object sender, EventArgs e)
        {
            if (FadeEffect)
                await FormUtils.FadeOutForm(Handle, 256);

            this.Close();
        }
        private async Task ScanFileAsync()
        {
            ResponseParser scanResponse  = new();
            bool isScanning = true;


            using (VT vt = new VT(VirusTotalAPIKey))
            {
                while (isScanning)
                {
                    var scanTask = vt.ScanFileAsync(vt, FileToScanPath!);

                    while (!scanTask.IsCompleted)
                    {
                        UpdateTitleStatus();
                        await Task.Delay(500);
                    }

                    scanResponse  = await scanTask;

                    if (scanResponse .IsComplete)
                        isScanning = false;
                }
            }
            // Handle API error
            if (scanResponse .ErrorCode != null)
            {
                MessageBox.Show($"Error:{scanResponse .ErrorCode.Code}", "API issues");
                return;
            }
            // Parse report
            await ParseReport(scanResponse );
        }

        private void UpdateTitleStatus()
        {
            dotCount = (dotCount + 1) % 4;
            eTheme1.Text = $"Scanning{new string('.', dotCount)}";
        }

        private async Task ParseReport(ResponseParser report)
        {
            // Update UI
            eTheme1.Text = $"Scan result:{report.FileInfo.SHA256}";
            lblFileSize.Text = $"{Constants.FileSizeLabel}{report.FileInfo.Size}";

            // Data
            foreach (var item in report.Results)
            {
                Invoke(new Action(() =>
                {
                    var engineResult = item.Value;
                    dgvResult.Rows.Add(
                        item.Key,  // AV (engine name)
                        engineResult.Category,
                        engineResult.EngineName,
                        engineResult.EngineVersion,
                        engineResult.Result,
                        engineResult.Method,
                        engineResult.EngineUpdate
                    );
                }));
            }
        }
    }
}
