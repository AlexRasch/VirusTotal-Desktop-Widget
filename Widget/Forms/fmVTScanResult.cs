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
        private string? VirusTotalAPIKey { get; set; }
        /// <summary>
        /// Gets or sets the file path to scan.
        /// </summary>
        private string? FileToScanPath { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the fade effect is enabled.
        /// </summary>
        private bool FadeEffect { get; set; }

        /// <summary>
        ///  Provides a way to cancel the scanning process by generating cancellation tokens.
        /// </summary>
        private CancellationTokenSource cancellationTokenSource = new();

        /// <summary>
        /// Keeps track of the number of dots to display in the 'Scanning...' text in UpdateTitleStatus method.
        /// </summary>
        private int dotCount = 0;

        /// <summary>
        ///  Initializes a new instance of the fmVTScanResult class when we have a report from VirusTotal to display.
        /// </summary>
        /// <param name="report">The VirusTotal response report to display.</param>
        /// <param name="fadeEffect">A flag indicating whether the fade effect is enabled (default: false).</param>
        public fmVTScanResult(ResponseParser report, bool fadeEffect = false)
        {
            InitializeComponent();
            this.Report = report;
            FadeEffect = fadeEffect;
        }
        /// <summary>
        /// Initializes a new instance of the fmVTScanResult class when we want to submit a file for scanning.
        /// </summary>
        /// <param name="filePath">The path to the file we want to scan.</param>
        /// <param name="virusTotalAPIKey">The API key to access the VirusTotal service.</param>
        /// <param name="fadeEffect">A flag indicating whether the fade effect is enabled (default: false).</param>
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
                _ = FormUtils.FadeInForm(Handle, 256);
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
                await PerformFileScanAsync();
        }
        private async void btnClose_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();

            if (FadeEffect)
                await FormUtils.FadeOutForm(Handle, 256);

            this.Close();
        }

        #region Scanning Methods

        /// <summary>
        /// Performs a file scanning using the VirusTotal API and passes the result to the ParseReport method.
        /// </summary>
        /// <returns>Nothing.</returns>
        private async Task PerformFileScanAsync()
        {
            ResponseParser scanResponse = new();
            bool isScanning = true;

            using (VT vt = new VT(VirusTotalAPIKey!))
            {
                try
                {
                    while (isScanning && !cancellationTokenSource.IsCancellationRequested)
                    {
                        var scanTask = vt.ScanFileAsync(vt, FileToScanPath!);

                        while (!scanTask.IsCompleted)
                        {
                            UpdateTitleStatus();
                            await Task.Delay(500);
                        }

                        scanResponse = await scanTask;

                        if (scanResponse.IsComplete)
                            isScanning = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during the scanning process.", "Scanning Error");
#if DEBUG
                    Debug.WriteLine("PerformFileScanAsync: Error { ex.Message}");
#endif
                    return;
                }
            }
            // Handle API error
            if (scanResponse.ErrorCode != null)
            {
                MessageBox.Show($"Error:{scanResponse.ErrorCode.Code}", "API issues");
                return;
            }
            // Parse report
            await ParseReport(scanResponse);
        }
        /// <summary>
        /// Updates the DataGridView with the report received from VirusTotal.
        /// </summary>
        /// <param name="report">The ResponseParser instance containing the scan report.</param>
        /// <returns>Nothing.</returns>
        private async Task ParseReport(ResponseParser report)
        {
            try
            {
                if (report == null)
                {
                    MessageBox.Show($"The report appears to be empty.", "Parse issue");
                    return;
                }

                // Update UI
                eTheme1.Text = $"Scan result:{report.FileInfo.SHA256}";
                lblFileSize.Text = $"{Constants.FileSizeLabel}{report.FileInfo.Size}";

                // DataBinding
                dgvResult.DataSource = report.Results.Values.ToList();
                dgvResult.Columns["colAV"].DataPropertyName = "EngineName";
                dgvResult.Columns["colCategory"].DataPropertyName = "Category";
                dgvResult.Columns["colEngineName"].DataPropertyName = "EngineName";
                dgvResult.Columns["colEngineVersion"].DataPropertyName = "EngineVersion";
                dgvResult.Columns["colResult"].DataPropertyName = "Result";
                dgvResult.Columns["colMethod"].DataPropertyName = "Method";
                dgvResult.Columns["colEngineUpdate"].DataPropertyName = "EngineUpdate";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while parsing.", "Parse error");
#if DEBUG
                Debug.WriteLine("ParseReport: Error { ex.Message}");
#endif
            }
        }

        private void dgvResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvResult.Columns["colCategory"].Index)
            {
                if (e.Value == null)
                    return;

                string category = e.Value.ToString();

                switch (category)
                {
                    case "harmless":
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.Green;
                        break;

                    case "suspicious":
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.Orange;
                        break;

                    case "malicious":
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.Red;
                        break;

                    default:
                        break;
                }
                e.FormattingApplied = true;
            }
        }


        /// <summary>
        /// Updates the title of the form to indicate the progress of the scanning process for the user.
        /// </summary>
        private void UpdateTitleStatus()
        {
            dotCount = (dotCount + 1) % 4;
            eTheme1.Text = $"Scanning{new string('.', dotCount)}";
        }

        #endregion
    }
}
