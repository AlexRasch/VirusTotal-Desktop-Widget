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
            lblSettings = new Label();
            ((System.ComponentModel.ISupportInitialize)pbSubmit).BeginInit();
            SuspendLayout();
            // 
            // pbSubmit
            // 
            pbSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbSubmit.BackColor = Color.Transparent;
            pbSubmit.BackgroundImageLayout = ImageLayout.Stretch;
            pbSubmit.Image = Properties.Resources.square_targeting;
            pbSubmit.Location = new Point(21, 196);
            pbSubmit.Name = "pbSubmit";
            pbSubmit.Size = new Size(223, 92);
            pbSubmit.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSubmit.TabIndex = 0;
            pbSubmit.TabStop = false;
            pbSubmit.Click += pbSubmit_Click;
            pbSubmit.DragDrop += pbScan_DragDrop;
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
            lblExit.ForeColor = Color.Firebrick;
            lblExit.Location = new Point(220, 9);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(24, 25);
            lblExit.TabIndex = 8;
            lblExit.Text = "X";
            lblExit.Click += lblExit_Click;
            lblExit.MouseEnter += lblExit_MouseEnter;
            lblExit.MouseLeave += lblExit_MouseLeave;
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.BackColor = Color.Transparent;
            lblSettings.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSettings.ForeColor = Color.WhiteSmoke;
            lblSettings.Location = new Point(190, 9);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(23, 25);
            lblSettings.TabIndex = 9;
            lblSettings.Text = "S";
            lblSettings.Click += lblSettings_Click;
            lblSettings.MouseEnter += lblSettings_MouseEnter;
            lblSettings.MouseLeave += lblSettings_MouseLeave;
            // 
            // frmWidget
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(260, 300);
            Controls.Add(pbSubmit);
            Controls.Add(lblSettings);
            Controls.Add(lblExit);
            Controls.Add(pbCPU);
            Controls.Add(pbRAM);
            Controls.Add(lblRAM);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmWidget";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VirustTotal desktop widget";
            Load += frmWidget_Load;
            MouseDown += frmWidget_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pbSubmit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSubmit;
        private Label label1;
        private Label lblRAM;
        private ProgressBar pbRAM;
        private ProgressBar pbCPU;
        private Label lblExit;
        private Label lblSettings;
    }
}