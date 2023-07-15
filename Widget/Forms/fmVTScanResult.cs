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

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
        
        private void fmVTScanResult_Load(object sender, EventArgs e)
        {
            eTheme1.Text = $"Report: {Report.FileInfo.SHA256}";

            this.MinimumSize = new Size(Width, Height);
            this.MaximumSize = this.MinimumSize;

            // Clear gridview
            dgvResult.Rows.Clear();

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
