namespace Widget
{
    partial class fmSettings
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
            gbVirusTotal = new GroupBox();
            txtApiKey = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            cbFadeEffect = new CheckBox();
            cbAutostart = new CheckBox();
            lblAutoStart = new Label();
            gbVirusTotal.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // gbVirusTotal
            // 
            gbVirusTotal.Controls.Add(txtApiKey);
            gbVirusTotal.Controls.Add(label1);
            gbVirusTotal.Location = new Point(12, 12);
            gbVirusTotal.Name = "gbVirusTotal";
            gbVirusTotal.Size = new Size(651, 64);
            gbVirusTotal.TabIndex = 0;
            gbVirusTotal.TabStop = false;
            gbVirusTotal.Text = "VirusTotal";
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(114, 25);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(523, 23);
            txtApiKey.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 28);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Virustotal API key:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(554, 407);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(109, 31);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbFadeEffect);
            groupBox1.Controls.Add(cbAutostart);
            groupBox1.Controls.Add(lblAutoStart);
            groupBox1.Location = new Point(12, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(651, 100);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Widget";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 3;
            label2.Text = "Fade effect:";
            // 
            // cbFadeEffect
            // 
            cbFadeEffect.AutoSize = true;
            cbFadeEffect.Location = new Point(77, 57);
            cbFadeEffect.Name = "cbFadeEffect";
            cbFadeEffect.Size = new Size(15, 14);
            cbFadeEffect.TabIndex = 2;
            cbFadeEffect.UseVisualStyleBackColor = true;
            // 
            // cbAutostart
            // 
            cbAutostart.AutoSize = true;
            cbAutostart.Location = new Point(77, 31);
            cbAutostart.Name = "cbAutostart";
            cbAutostart.Size = new Size(15, 14);
            cbAutostart.TabIndex = 1;
            cbAutostart.UseVisualStyleBackColor = true;
            // 
            // lblAutoStart
            // 
            lblAutoStart.AutoSize = true;
            lblAutoStart.Location = new Point(6, 30);
            lblAutoStart.Name = "lblAutoStart";
            lblAutoStart.Size = new Size(59, 15);
            lblAutoStart.TabIndex = 0;
            lblAutoStart.Text = "Autostart:";
            // 
            // fmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 450);
            Controls.Add(groupBox1);
            Controls.Add(btnSave);
            Controls.Add(gbVirusTotal);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmSettings";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Settings";
            Load += fmSettings_Load;
            gbVirusTotal.ResumeLayout(false);
            gbVirusTotal.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbVirusTotal;
        private TextBox txtApiKey;
        private Label label1;
        private Button btnSave;
        private GroupBox groupBox1;
        private Label lblAutoStart;
        private CheckBox cbAutostart;
        private Label label2;
        private CheckBox cbFadeEffect;
    }
}