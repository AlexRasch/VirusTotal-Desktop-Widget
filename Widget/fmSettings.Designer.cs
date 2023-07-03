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
            gbVirusTotal.SuspendLayout();
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
            // fmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 450);
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
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbVirusTotal;
        private TextBox txtApiKey;
        private Label label1;
        private Button btnSave;
    }
}