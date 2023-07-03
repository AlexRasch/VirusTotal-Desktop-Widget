namespace Widget
{
    partial class fmVTScanResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvResult = new DataGridView();
            mtVTScanResult = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            mtVTScanResult.SuspendLayout();
            SuspendLayout();
            // 
            // dgvResult
            // 
            dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Dock = DockStyle.Fill;
            dgvResult.Location = new Point(0, 30);
            dgvResult.Margin = new Padding(3, 4, 3, 4);
            dgvResult.Name = "dgvResult";
            dgvResult.RowHeadersWidth = 51;
            dgvResult.RowTemplate.Height = 25;
            dgvResult.Size = new Size(789, 570);
            dgvResult.TabIndex = 0;
            // 
            // mtVTScanResult
            // 
            mtVTScanResult.ImageScalingSize = new Size(20, 20);
            mtVTScanResult.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, fileToolStripMenuItem });
            mtVTScanResult.Location = new Point(0, 0);
            mtVTScanResult.Name = "mtVTScanResult";
            mtVTScanResult.Padding = new Padding(7, 3, 0, 3);
            mtVTScanResult.Size = new Size(789, 30);
            mtVTScanResult.TabIndex = 1;
            mtVTScanResult.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 24);
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(224, 26);
            exportToolStripMenuItem.Text = "Export";
            // 
            // fmVTScanResult
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 600);
            Controls.Add(dgvResult);
            Controls.Add(mtVTScanResult);
            MainMenuStrip = mtVTScanResult;
            Margin = new Padding(3, 4, 3, 4);
            Name = "fmVTScanResult";
            Text = "fmVTScanResult";
            Load += fmVTScanResult_Load;
            Resize += fmVTScanResult_Resize;
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            mtVTScanResult.ResumeLayout(false);
            mtVTScanResult.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvResult;
        private MenuStrip mtVTScanResult;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
    }
}