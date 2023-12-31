﻿using System;
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
        /// Gets or sets the path to the report VirusTotal to import
        /// </summary>
        private string? ReportFilePath { get; set; }


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
        public fmVTScanResult(string reportFilePath, bool fadeEffect = false)
        {
            if (string.IsNullOrEmpty(reportFilePath))
            {
                MessageBox.Show(Constants.ReportPathIsEmpty, Constants.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ReportFilePath = reportFilePath;
            FadeEffect = fadeEffect;
            InitializeComponent();
        }
        /// <summary>
        /// Initializes a new instance of the fmVTScanResult class when we want to submit a file for scanning.
        /// </summary>
        /// <param name="filePath">The path to the file we want to scan.</param>
        /// <param name="virusTotalAPIKey">The API key to access the VirusTotal service.</param>
        /// <param name="fadeEffect">A flag indicating whether the fade effect is enabled (default: false).</param>
        public fmVTScanResult(string filePath, string virusTotalAPIKey, bool fadeEffect = false)
        {
            FileToScanPath = filePath;
            VirusTotalAPIKey = virusTotalAPIKey;
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

            // This fixes the issues related to databinding adding cols we dont need
            SetupDataGridView();

            // Should we read a existing report?
            if(!string.IsNullOrEmpty(ReportFilePath))
                Report = await ReadReportAsync(ReportFilePath, Report);

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
        #region Export - UI
        /// <summary>
        ///  Handles the export of the VirusTotal scan results to a file.
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if(Report?.RawResponse == null)
            {
                MessageBox.Show(Constants.SaveFileDialogNothingToExport, Constants.SaveFileDialogNothingToExportTitle);
                return;
            }

            using SaveFileDialog saveFileDialog = new();
            saveFileDialog.Title = Constants.SaveFileDialogTitle;
            saveFileDialog.Filter = "JSON|*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileIOManager exporter = new(Report!.RawResponse, saveFileDialog.FileName);

                // Check if any error occured
                if (!exporter.WriteFile())
                {
                    // We have a error message
                    if (exporter.HasError)
                    {
                        string errorMessage = Constants.SaveFileDialogExportError + Environment.NewLine + exporter.ErrorMessage;
                        MessageBox.Show(errorMessage, Constants.SaveFileDialogExportErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(Constants.SaveFileDialogExportError, Constants.SaveFileDialogExportErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
        #region DataGrid and Binding fix

        /// <summary>
        /// Sets up the DataGridView control by configuring its properties and columns.
        /// </summary>
        /// <remarks>
        /// This method includes a workaround to remove the extra column that is added automatically due to the way data binding works.
        /// </remarks>
        private void SetupDataGridView()
        {
            // Disable auto-generated columns
            dgvResult.AutoGenerateColumns = false;

            // Clear all cols
            dgvResult.Columns.Clear();

            // Add and configure the desired columns
            dgvResult.Columns.Add(CreateColumn("colAV", "AV"));
            dgvResult.Columns.Add(CreateColumn("colCategory", "Category"));
            dgvResult.Columns.Add(CreateColumn("colEngineName", "Name"));
            dgvResult.Columns.Add(CreateColumn("colEngineVersion", "Version"));
            dgvResult.Columns.Add(CreateColumn("colResult", "Result"));
            dgvResult.Columns.Add(CreateColumn("colMethod", "Method"));
            dgvResult.Columns.Add(CreateColumn("colEngineUpdate", "Updated"));
        }

        /// <summary>
        /// Creates a DataGridViewColumn with the specified name and header text.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <param name="headerText">The header text displayed in the column's header.</param>
        /// <returns>The created DataGridViewColumn.</returns>
        private DataGridViewColumn CreateColumn(string name, string headerText)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = headerText,
                DataPropertyName = name,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
        }

        #endregion
        #region Import Report
        
        /// <summary>
        /// Reads and parses the VirusTotal report from the specified file path.
        /// </summary>
        /// <param name="pathToReport">The full file path to the VirusTotal report file.</param>
        /// <param name="report">An optional existing <see cref="ResponseParser"/> instance to store the parsed report. If not provided, a new instance will be created.</param>
        /// <returns>A <see cref="ResponseParser"/> containing the parsed report data, or null if an error occurred during file reading or parsing.</returns>
        private async Task<ResponseParser?> ReadReportAsync(string pathToReport, ResponseParser? report)
        {
            try
            {
                // Read it
                FileIOManager importer = new(ReportFilePath!);
                if (importer.ReadFile(out string fileContent))
                {
                    // Parse it
                    report = new ResponseParser();
                    return report.ParseReport(fileContent);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"ReadReportAsync: {ex.Message}");
#endif
                return null;
            }
        }

        #endregion
        #region Scanning Methods

        /// <summary>
        /// Performs a file scanning using the VirusTotal API and passes the result to the ParseReport method.
        /// </summary>
        /// <returns>Nothing.</returns>
        private async Task PerformFileScanAsync()
        {
            ResponseParser scanResponse = new();
            bool isScanning = true;

            using (VT vt = new(VirusTotalAPIKey!))
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
                    MessageBox.Show(Constants.ErrorDuringScan, Constants.ErrorDuringScanTitle);
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
            // Store it incase user wants to export it
            Report = scanResponse;
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
                    MessageBox.Show(Constants.ParseReportEmpty, Constants.ParseReportEmptyTitle);
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
