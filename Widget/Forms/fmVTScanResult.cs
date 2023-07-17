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
        // For VT scan result
        private VT vt;
        private ResponseParser? Report { get; set; }
        private string? FileToScanPath { get; set; }
        private bool FadeEffect { get; set; }

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
            this.vt = new(virusTotalAPIKey);

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
            // Scan file
            ResponseParser vtReponse = new();
            vtReponse = await vt.ScanFileAsync(vt, FileToScanPath!);
            // Handle API error
            if (vtReponse.ErrorCode != null)
            {
                MessageBox.Show($"Error:{vtReponse.ErrorCode.Code}", "API issues");
                return;
            }
            // Parse report
            await ParseReport(vtReponse);
        }

        private async Task ParseReport(ResponseParser report)
        {
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
