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
            pbScan = new PictureBox();
            pictureBox2 = new PictureBox();
            pbSettings = new PictureBox();
            label1 = new Label();
            lblRAM = new Label();
            pbRAM = new ProgressBar();
            pbCPU = new ProgressBar();
            lblExit = new Label();
            ((System.ComponentModel.ISupportInitialize)pbSubmit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbScan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSettings).BeginInit();
            SuspendLayout();
            // 
            // pbSubmit
            // 
            pbSubmit.Anchor = AnchorStyles.Bottom;
            pbSubmit.BackColor = Color.Transparent;
            pbSubmit.Image = Properties.Resources.submit;
            pbSubmit.Location = new Point(140, 220);
            pbSubmit.Name = "pbSubmit";
            pbSubmit.Size = new Size(104, 70);
            pbSubmit.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSubmit.TabIndex = 0;
            pbSubmit.TabStop = false;
            pbSubmit.Click += pbScan_Click;
            pbSubmit.DragDrop += pbScan_DragDrop;
            // 
            // pbScan
            // 
            pbScan.Anchor = AnchorStyles.Bottom;
            pbScan.BackColor = Color.Transparent;
            pbScan.Image = Properties.Resources.scan;
            pbScan.Location = new Point(15, 220);
            pbScan.Name = "pbScan";
            pbScan.Size = new Size(104, 70);
            pbScan.SizeMode = PictureBoxSizeMode.StretchImage;
            pbScan.TabIndex = 1;
            pbScan.TabStop = false;
            pbScan.Click += pbScan_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Location = new Point(140, 140);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(104, 70);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pbSettings
            // 
            pbSettings.Anchor = AnchorStyles.Bottom;
            pbSettings.BackColor = Color.Transparent;
            pbSettings.Image = Properties.Resources.settings;
            pbSettings.Location = new Point(15, 140);
            pbSettings.Name = "pbSettings";
            pbSettings.Size = new Size(104, 70);
            pbSettings.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSettings.TabIndex = 3;
            pbSettings.TabStop = false;
            pbSettings.Click += pbSettings_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(15, 26);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 4;
            label1.Text = "CPU";
            // 
            // lblRAM
            // 
            lblRAM.AutoSize = true;
            lblRAM.BackColor = Color.Transparent;
            lblRAM.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblRAM.ForeColor = Color.WhiteSmoke;
            lblRAM.Location = new Point(15, 67);
            lblRAM.Name = "lblRAM";
            lblRAM.Size = new Size(52, 25);
            lblRAM.TabIndex = 5;
            lblRAM.Text = "RAM";
            // 
            // pbRAM
            // 
            pbRAM.Location = new Point(21, 92);
            pbRAM.Margin = new Padding(3, 2, 3, 2);
            pbRAM.Name = "pbRAM";
            pbRAM.Size = new Size(223, 8);
            pbRAM.Step = 1;
            pbRAM.TabIndex = 6;
            pbRAM.Value = 23;
            // 
            // pbCPU
            // 
            pbCPU.Location = new Point(21, 52);
            pbCPU.Margin = new Padding(3, 2, 3, 2);
            pbCPU.Name = "pbCPU";
            pbCPU.Size = new Size(223, 8);
            pbCPU.Step = 1;
            pbCPU.TabIndex = 7;
            pbCPU.Value = 40;
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.BackColor = Color.Transparent;
            lblExit.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblExit.ForeColor = Color.IndianRed;
            lblExit.Location = new Point(220, 9);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(24, 25);
            lblExit.TabIndex = 8;
            lblExit.Text = "X";
            lblExit.Click += lblExit_Click;
            // 
            // frmWidget
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.bg_outrun;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(260, 300);
            Controls.Add(lblExit);
            Controls.Add(pbCPU);
            Controls.Add(pbRAM);
            Controls.Add(lblRAM);
            Controls.Add(label1);
            Controls.Add(pbSettings);
            Controls.Add(pictureBox2);
            Controls.Add(pbScan);
            Controls.Add(pbSubmit);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmWidget";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VT-Desktop-Widget";
            Load += frmWidget_Load;
            MouseDown += frmWidget_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pbSubmit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbScan).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSettings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSubmit;
        private PictureBox pbScan;
        private PictureBox pictureBox2;
        private PictureBox pbSettings;
        private Label label1;
        private Label lblRAM;
        private ProgressBar pbRAM;
        private ProgressBar pbCPU;
        private Label lblExit;
    }
}