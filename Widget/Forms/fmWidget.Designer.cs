namespace Widget
{
    partial class frmWidget
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbSubmit = new PictureBox();
            label1 = new Label();
            lblRAM = new Label();
            pbRAM = new ProgressBar();
            pbCPU = new ProgressBar();
            lblExit = new Label();
            eTheme1 = new Forms.eTheme();
            pbImportReport = new PictureBox();
            btnSettings = new Forms.eButton();
            ((System.ComponentModel.ISupportInitialize)pbSubmit).BeginInit();
            eTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImportReport).BeginInit();
            SuspendLayout();
            // 
            // pbSubmit
            // 
            pbSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbSubmit.BackColor = Color.Transparent;
            pbSubmit.BackgroundImageLayout = ImageLayout.Stretch;
            pbSubmit.Image = Properties.Resources.submit;
            pbSubmit.Location = new Point(23, 261);
            pbSubmit.Margin = new Padding(3, 4, 3, 4);
            pbSubmit.Name = "pbSubmit";
            pbSubmit.Size = new Size(114, 123);
            pbSubmit.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSubmit.TabIndex = 0;
            pbSubmit.TabStop = false;
            pbSubmit.Click += pbSubmit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(24, 59);
            label1.Name = "label1";
            label1.Size = new Size(57, 31);
            label1.TabIndex = 4;
            label1.Text = "CPU";
            // 
            // lblRAM
            // 
            lblRAM.AutoSize = true;
            lblRAM.BackColor = Color.Transparent;
            lblRAM.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblRAM.ForeColor = Color.WhiteSmoke;
            lblRAM.Location = new Point(24, 108);
            lblRAM.Name = "lblRAM";
            lblRAM.Size = new Size(64, 31);
            lblRAM.TabIndex = 5;
            lblRAM.Text = "RAM";
            // 
            // pbRAM
            // 
            pbRAM.Location = new Point(24, 144);
            pbRAM.Name = "pbRAM";
            pbRAM.Size = new Size(255, 11);
            pbRAM.Step = 1;
            pbRAM.TabIndex = 6;
            pbRAM.Value = 23;
            // 
            // pbCPU
            // 
            pbCPU.Location = new Point(24, 95);
            pbCPU.Name = "pbCPU";
            pbCPU.Size = new Size(255, 11);
            pbCPU.Step = 1;
            pbCPU.TabIndex = 7;
            pbCPU.Value = 40;
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.BackColor = Color.Transparent;
            lblExit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblExit.ForeColor = Color.Firebrick;
            lblExit.Location = new Point(241, 0);
            lblExit.Margin = new Padding(0);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(35, 31);
            lblExit.TabIndex = 8;
            lblExit.Text = " X";
            lblExit.Click += lblExit_Click;
            lblExit.MouseEnter += lblExit_MouseEnter;
            lblExit.MouseLeave += lblExit_MouseLeave;
            // 
            // eTheme1
            // 
            eTheme1.BackColor = Color.FromArgb(53, 53, 53);
            eTheme1.Controls.Add(pbImportReport);
            eTheme1.Controls.Add(btnSettings);
            eTheme1.Controls.Add(pbSubmit);
            eTheme1.Controls.Add(lblRAM);
            eTheme1.Controls.Add(pbCPU);
            eTheme1.Controls.Add(lblExit);
            eTheme1.Controls.Add(label1);
            eTheme1.Dock = DockStyle.Fill;
            eTheme1.Image = null;
            eTheme1.Location = new Point(0, 0);
            eTheme1.Margin = new Padding(3, 4, 3, 4);
            eTheme1.MoveHeight = 30;
            eTheme1.Name = "eTheme1";
            eTheme1.Resizable = false;
            eTheme1.Size = new Size(297, 400);
            eTheme1.TabIndex = 10;
            eTheme1.Text = "VirusTotal Widget";
            eTheme1.TransparencyKey = Color.Empty;
            // 
            // pbImportReport
            // 
            pbImportReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbImportReport.BackColor = Color.Transparent;
            pbImportReport.BackgroundImageLayout = ImageLayout.Stretch;
            pbImportReport.Image = Properties.Resources.import_report;
            pbImportReport.Location = new Point(165, 261);
            pbImportReport.Margin = new Padding(3, 4, 3, 4);
            pbImportReport.Name = "pbImportReport";
            pbImportReport.Size = new Size(114, 123);
            pbImportReport.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImportReport.TabIndex = 11;
            pbImportReport.TabStop = false;
            pbImportReport.Click += pbImportReport_Click;
            // 
            // btnSettings
            // 
            btnSettings.Image = null;
            btnSettings.Location = new Point(24, 191);
            btnSettings.Margin = new Padding(3, 4, 3, 4);
            btnSettings.Name = "btnSettings";
            btnSettings.NoRounding = false;
            btnSettings.Size = new Size(75, 37);
            btnSettings.TabIndex = 10;
            btnSettings.Text = "Settings";
            btnSettings.Click += btnSettings_Click;
            // 
            // frmWidget
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(297, 400);
            Controls.Add(pbRAM);
            Controls.Add(eTheme1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmWidget";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VirustTotal desktop widget";
            Load += frmWidget_Load;
            ((System.ComponentModel.ISupportInitialize)pbSubmit).EndInit();
            eTheme1.ResumeLayout(false);
            eTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbImportReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbSubmit;
        private Label label1;
        private Label lblRAM;
        private ProgressBar pbRAM;
        private ProgressBar pbCPU;
        private Label lblExit;
        private Forms.eTheme eTheme1;
        private Forms.eButton btnSettings;
        private PictureBox pbImportReport;
    }
}