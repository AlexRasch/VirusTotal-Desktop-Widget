﻿namespace Widget
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
            Forms.Pigment pigment1 = new Forms.Pigment();
            Forms.Pigment pigment2 = new Forms.Pigment();
            Forms.Pigment pigment3 = new Forms.Pigment();
            Forms.Pigment pigment4 = new Forms.Pigment();
            Forms.Pigment pigment5 = new Forms.Pigment();
            Forms.Pigment pigment6 = new Forms.Pigment();
            Forms.Pigment pigment7 = new Forms.Pigment();
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
            txtApiKey.BorderStyle = BorderStyle.None;
            txtApiKey.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtApiKey.Location = new Point(165, 28);
            txtApiKey.Margin = new Padding(3, 4, 3, 4);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(392, 25);
            txtApiKey.TabIndex = 1;
            txtApiKey.TextChanged += txtApiKey_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(6, 26);
            label1.Name = "label1";
            label1.Size = new Size(169, 28);
            label1.TabIndex = 0;
            label1.Text = "Virustotal API key:";
            // 
            // lblSendTo
            // 
            lblSendTo.AutoSize = true;
            lblSendTo.BackColor = Color.Transparent;
            lblSendTo.ForeColor = Color.WhiteSmoke;
            lblSendTo.Location = new Point(189, 17);
            lblSendTo.Name = "lblSendTo";
            lblSendTo.Size = new Size(63, 20);
            lblSendTo.TabIndex = 5;
            lblSendTo.Text = "Send to:";
            // 
            // cbSendTo
            // 
            cbSendTo.AutoSize = true;
            cbSendTo.Location = new Point(253, 19);
            cbSendTo.Margin = new Padding(3, 4, 3, 4);
            cbSendTo.Name = "cbSendTo";
            cbSendTo.Size = new Size(18, 17);
            cbSendTo.TabIndex = 4;
            cbSendTo.UseVisualStyleBackColor = true;
            // 
            // lblFadeEffect
            // 
            lblFadeEffect.AutoSize = true;
            lblFadeEffect.BackColor = Color.Transparent;
            lblFadeEffect.ForeColor = Color.WhiteSmoke;
            lblFadeEffect.Location = new Point(8, 51);
            lblFadeEffect.Name = "lblFadeEffect";
            lblFadeEffect.Size = new Size(85, 20);
            lblFadeEffect.TabIndex = 3;
            lblFadeEffect.Text = "Fade effect:";
            // 
            // cbFadeEffect
            // 
            cbFadeEffect.AutoSize = true;
            cbFadeEffect.Location = new Point(98, 53);
            cbFadeEffect.Margin = new Padding(3, 4, 3, 4);
            cbFadeEffect.Name = "cbFadeEffect";
            cbFadeEffect.Size = new Size(18, 17);
            cbFadeEffect.TabIndex = 2;
            cbFadeEffect.UseVisualStyleBackColor = true;
            // 
            // cbAutostart
            // 
            cbAutostart.AutoSize = true;
            cbAutostart.Location = new Point(98, 19);
            cbAutostart.Margin = new Padding(3, 4, 3, 4);
            cbAutostart.Name = "cbAutostart";
            cbAutostart.Size = new Size(18, 17);
            cbAutostart.TabIndex = 1;
            cbAutostart.UseVisualStyleBackColor = true;
            // 
            // lblAutoStart
            // 
            lblAutoStart.AutoSize = true;
            lblAutoStart.BackColor = Color.Transparent;
            lblAutoStart.ForeColor = Color.WhiteSmoke;
            lblAutoStart.Location = new Point(17, 17);
            lblAutoStart.Name = "lblAutoStart";
            lblAutoStart.Size = new Size(73, 20);
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
            eTheme1.Margin = new Padding(3, 4, 3, 4);
            eTheme1.MoveHeight = 30;
            eTheme1.Name = "eTheme1";
            eTheme1.Resizable = true;
            eTheme1.Size = new Size(686, 400);
            eTheme1.TabIndex = 3;
            eTheme1.Text = "Settings";
            eTheme1.TransparencyKey = Color.Empty;
            // 
            // eGroupBox2
            // 
            eGroupBox2.Location = new Point(359, 171);
            eGroupBox2.Margin = new Padding(3, 4, 3, 4);
            eGroupBox2.Name = "eGroupBox2";
            eGroupBox2.NoRounding = false;
            eGroupBox2.Size = new Size(313, 148);
            eGroupBox2.TabIndex = 9;
            eGroupBox2.Text = "eGroupBox2";
            // 
            // btnCancel
            // 
            btnCancel.Image = null;
            btnCancel.Location = new Point(16, 343);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.NoRounding = false;
            btnCancel.Size = new Size(149, 40);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            pigment1.Name = "Border";
            pigment1.Value = Color.FromArgb(254, 133, 0);
            pigment2.Name = "Backcolor";
            pigment2.Value = Color.FromArgb(25, 25, 25);
            pigment3.Name = "Highlight";
            pigment3.Value = Color.FromArgb(255, 197, 19);
            pigment4.Name = "Gradient1";
            pigment4.Value = Color.FromArgb(255, 175, 12);
            pigment5.Name = "Gradient2";
            pigment5.Value = Color.FromArgb(255, 127, 1);
            pigment6.Name = "Text Color";
            pigment6.Value = Color.White;
            pigment7.Name = "Text Shadow";
            pigment7.Value = Color.FromArgb(30, 0, 0, 0);
            btnSave.Colors = new Forms.Pigment[] { pigment1, pigment2, pigment3, pigment4, pigment5, pigment6, pigment7 };
            btnSave.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(517, 343);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Shadow = true;
            btnSave.Size = new Size(149, 40);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // eGroupBox1
            // 
            eGroupBox1.Controls.Add(btnView);
            eGroupBox1.Controls.Add(label1);
            eGroupBox1.Controls.Add(txtApiKey);
            eGroupBox1.Location = new Point(16, 55);
            eGroupBox1.Margin = new Padding(3, 4, 3, 4);
            eGroupBox1.Name = "eGroupBox1";
            eGroupBox1.NoRounding = false;
            eGroupBox1.Size = new Size(656, 108);
            eGroupBox1.TabIndex = 6;
            eGroupBox1.Text = "gbSettingsVirusTotal";
            // 
            // btnView
            // 
            btnView.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnView.Image = null;
            btnView.Location = new Point(563, 24);
            btnView.Margin = new Padding(3, 4, 3, 4);
            btnView.Name = "btnView";
            btnView.NoRounding = false;
            btnView.Size = new Size(86, 33);
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
            gbWidgetSettings.Location = new Point(16, 171);
            gbWidgetSettings.Margin = new Padding(3, 4, 3, 4);
            gbWidgetSettings.Name = "gbWidgetSettings";
            gbWidgetSettings.NoRounding = false;
            gbWidgetSettings.Size = new Size(336, 148);
            gbWidgetSettings.TabIndex = 5;
            gbWidgetSettings.Text = "eGroupBox1";
            // 
            // fmSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 400);
            Controls.Add(eTheme1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
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