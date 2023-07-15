using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirusTotal;

namespace Widget
{
#pragma warning disable IDE1006
    public partial class fmVTScanResult : Form
    {
        // For VT scan result
        private ResponseParser Report { get; set; }

        public fmVTScanResult(ResponseParser report)
        {
            InitializeComponent();
            this.Report = report;
        }

        private void fmVTScanResult_Resize(object sender, EventArgs e)
        {
            //dgvResult.Size = new Size(this.ClientSize.Width - dgvResult.Left * 2, this.ClientSize.Height - dgvResult.Top - dgvResult.Left);
        }

        private void fmVTScanResult_Load(object sender, EventArgs e)
        {
            this.Text = $"Report: {Report.FileInfo.SHA256}";
            // Clear gridview
            dgvResult.Rows.Clear();

            // Cols
            dgvResult.Columns.Add("colAV", "AV");
            dgvResult.Columns.Add("colCategory", "Category");
            dgvResult.Columns.Add("colEngineName", "Engine");
            dgvResult.Columns.Add("colEngineVersion", "Version");
            dgvResult.Columns.Add("colResult", "Result");
            dgvResult.Columns.Add("colMethod", "Method");
            dgvResult.Columns.Add("colEngineUpdate", "Updated");

            // Data
            foreach (var item in Report.Results)
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
            }

        }


    }
}
