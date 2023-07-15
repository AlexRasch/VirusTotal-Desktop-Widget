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
            Forms.Pigment pigment8 = new Forms.Pigment();
            Forms.Pigment pigment9 = new Forms.Pigment();
            Forms.Pigment pigment10 = new Forms.Pigment();
            Forms.Pigment pigment11 = new Forms.Pigment();
            Forms.Pigment pigment12 = new Forms.Pigment();
            Forms.Pigment pigment13 = new Forms.Pigment();
            Forms.Pigment pigment14 = new Forms.Pigment();
            txtApiKey = new TextBox();
            label1 = new Label();
            lblSendTo = new Label();
            cbSendTo = new CheckBox();
            lblFadeEffect = new Label();
            cbFadeEffect = new CheckBox();
            cbAutostart = new CheckBox();
            lblAutoStart = new Label();
            eTheme1 = new Forms.eTheme();
            eGroupBox2 = new Forms.eGroupBox();
            btnCancel = new Forms.eButton();
            btnSave = new Forms.FButton();
            eGroupBox1 = new Forms.eGroupBox();
            btnView = new Forms.eButton();
            gbWidgetSettings = new Forms.eGroupBox();
            eTheme1.SuspendLayout();
            eGroupBox1.SuspendLayout();
            gbWidgetSettings.SuspendLayout();
            SuspendLayout();
            // 
            // txtApiKey
            // 
            txtApiKey.BorderStyle = BorderStyle.FixedSingle;
            txtApiKey.Location = new Point(123, 22);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(343, 23);
            txtApiKey.TabIndex = 1;
            txtApiKey.TextChanged += txtApiKey_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(15, 24);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Virustotal API key:";
            // 
            // lblSendTo
            // 
            lblSendTo.AutoSize = true;
            lblSendTo.BackColor = Color.Transparent;
            lblSendTo.ForeColor = Color.WhiteSmoke;
            lblSendTo.Location = new Point(165, 13);
            lblSendTo.Name = "lblSendTo";
            lblSendTo.Size = new Size(50, 15);
            lblSendTo.TabIndex = 5;
            lblSendTo.Text = "Send to:";
            // 
            // cbSendTo
            // 
            cbSendTo.AutoSize = true;
            cbSendTo.Location = new Point(221, 14);
            cbSendTo.Name = "cbSendTo";
            cbSendTo.Size = new Size(15, 14);
            cbSendTo.TabIndex = 4;
            cbSendTo.UseVisualStyleBackColor = true;
            // 
            // lblFadeEffect
            // 
            lblFadeEffect.AutoSize = true;
            lblFadeEffect.BackColor = Color.Transparent;
            lblFadeEffect.ForeColor = Color.WhiteSmoke;
            lblFadeEffect.Location = new Point(15, 39);
            lblFadeEffect.Name = "lblFadeEffect";
            lblFadeEffect.Size = new Size(68, 15);
            lblFadeEffect.TabIndex = 3;
            lblFadeEffect.Text = "Fade effect:";
            // 
            // cbFadeEffect
            // 
            cbFadeEffect.AutoSize = true;
            cbFadeEffect.Location = new Point(86, 40);
            cbFadeEffect.Name = "cbFadeEffect";
            cbFadeEffect.Size = new Size(15, 14);
            cbFadeEffect.TabIndex = 2;
            cbFadeEffect.UseVisualStyleBackColor = true;
            // 
            // cbAutostart
            // 
            cbAutostart.AutoSize = true;
            cbAutostart.Location = new Point(86, 14);
            cbAutostart.Name = "cbAutostart";
            cbAutostart.Size = new Size(15, 14);
            cbAutostart.TabIndex = 1;
            cbAutostart.UseVisualStyleBackColor = true;
            // 
            // lblAutoStart
            // 
            lblAutoStart.AutoSize = true;
            lblAutoStart.BackColor = Color.Transparent;
            lblAutoStart.ForeColor = Color.WhiteSmoke;
            lblAutoStart.Location = new Point(15, 13);
            lblAutoStart.Name = "lblAutoStart";
            lblAutoStart.Size = new Size(59, 15);
            lblAutoStart.TabIndex = 0;
            lblAutoStart.Text = "Autostart:";
            // 
            // eTheme1
            // 
            eTheme1.BackColor = Color.FromArgb(53, 53, 53);
            eTheme1.Controls.Add(eGroupBox2);
            eTheme1.Controls.Add(btnCancel);
            eTheme1.Controls.Add(btnSave);
            eTheme1.Controls.Add(eGroupBox1);
            eTheme1.Controls.Add(gbWidgetSettings);
            eTheme1.Dock = DockStyle.Fill;
            eTheme1.Image = null;
            eTheme1.Location = new Point(0, 0);
            eTheme1.MoveHeight = 30;
            eTheme1.Name = "eTheme1";
            eTheme1.Resizable = true;
            eTheme1.Size = new Size(600, 300);
            eTheme1.TabIndex = 3;
            eTheme1.Text = "Settings";
            eTheme1.TransparencyKey = Color.Empty;
            // 
            // eGroupBox2
            // 
            eGroupBox2.Location = new Point(314, 128);
            eGroupBox2.Name = "eGroupBox2";
            eGroupBox2.NoRounding = false;
            eGroupBox2.Size = new Size(274, 111);
            eGroupBox2.TabIndex = 9;
            eGroupBox2.Text = "eGroupBox2";
            // 
            // btnCancel
            // 
            btnCancel.Image = null;
            btnCancel.Location = new Point(14, 257);
            btnCancel.Name = "btnCancel";
            btnCancel.NoRounding = false;
            btnCancel.Size = new Size(130, 30);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            pigment8.Name = "Border";
            pigment8.Value = Color.FromArgb(254, 133, 0);
            pigment9.Name = "Backcolor";
            pigment9.Value = Color.FromArgb(25, 25, 25);
            pigment10.Name = "Highlight";
            pigment10.Value = Color.FromArgb(255, 197, 19);
            pigment11.Name = "Gradient1";
            pigment11.Value = Color.FromArgb(255, 175, 12);
            pigment12.Name = "Gradient2";
            pigment12.Value = Color.FromArgb(255, 127, 1);
            pigment13.Name = "Text Color";
            pigment13.Value = Color.White;
            pigment14.Name = "Text Shadow";
            pigment14.Value = Color.FromArgb(30, 0, 0, 0);
            btnSave.Colors = new Forms.Pigment[] { pigment8, pigment9, pigment10, pigment11, pigment12, pigment13, pigment14 };
            btnSave.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(452, 257);
            btnSave.Name = "btnSave";
            btnSave.Shadow = true;
            btnSave.Size = new Size(130, 30);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // eGroupBox1
            // 
            eGroupBox1.Controls.Add(btnView);
            eGroupBox1.Controls.Add(label1);
            eGroupBox1.Controls.Add(txtApiKey);
            eGroupBox1.Location = new Point(14, 41);
            eGroupBox1.Name = "eGroupBox1";
            eGroupBox1.NoRounding = false;
            eGroupBox1.Size = new Size(574, 81);
            eGroupBox1.TabIndex = 6;
            eGroupBox1.Text = "gbSettingsVirusTotal";
            // 
            // btnView
            // 
            btnView.Image = null;
            btnView.Location = new Point(472, 22);
            btnView.Name = "btnView";
            btnView.NoRounding = false;
            btnView.Size = new Size(75, 23);
            btnView.TabIndex = 2;
            btnView.Text = "View";
            btnView.Click += btnView_Click;
            // 
            // gbWidgetSettings
            // 
            gbWidgetSettings.Controls.Add(lblSendTo);
            gbWidgetSettings.Controls.Add(lblAutoStart);
            gbWidgetSettings.Controls.Add(cbSendTo);
            gbWidgetSettings.Controls.Add(cbAutostart);
            gbWidgetSettings.Controls.Add(lblFadeEffect);
            gbWidgetSettings.Controls.Add(cbFadeEffect);
            gbWidgetSettings.Location = new Point(14, 128);
            gbWidgetSettings.Name = "gbWidgetSettings";
            gbWidgetSettings.NoRounding = false;
            gbWidgetSettings.Size = new Size(294, 111);
            gbWidgetSettings.TabIndex = 5;
            gbWidgetSettings.Text = "eGroupBox1";
            // 
            // fmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(600, 300);
            Controls.Add(eTheme1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmSettings";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Settings";
            Load += fmSettings_Load;
            eTheme1.ResumeLayout(false);
            eGroupBox1.ResumeLayout(false);
            eGroupBox1.PerformLayout();
            gbWidgetSettings.ResumeLayout(false);
            gbWidgetSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtApiKey;
        private Label label1;
        //private Button btnSave;
        private Label lblAutoStart;
        private CheckBox cbAutostart;
        private Label lblFadeEffect;
        private CheckBox cbFadeEffect;
        private Label lblSendTo;
        private CheckBox cbSendTo;
        private Forms.eTheme eTheme1;
        private Forms.eGroupBox gbWidgetSettings;
        //private Forms.FButton btnSave;
        private Forms.eGroupBox eGroupBox1;
        private Forms.FButton btnSave;
        private Forms.eButton btnCancel;
        private Forms.eButton btnView;
        private Forms.eGroupBox eGroupBox2;
    }
}