using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Widget.WidgetConfiguration;

namespace Widget
{
#pragma warning disable IDE1006
    public partial class fmSettings : Form
    {
        WidgetSettings config = new();

        private bool ShowAPIKey = true;
        private string currentApiKey;

        public fmSettings()
        {
            InitializeComponent();

            // UX
            System.Windows.Forms.ToolTip toolTipAutoStart = new();
            toolTipAutoStart.SetToolTip(lblAutoStart, "Enable autostart to launch the widget automatically during Windows startup.");

            System.Windows.Forms.ToolTip toolTipFadeEffect = new();
            toolTipFadeEffect.SetToolTip(lblFadeEffect, "Enable this option to add a visually appealing fade-in and fade-out effect when the application starts and exits.");

            System.Windows.Forms.ToolTip toolTipSendTo = new();
            toolTipSendTo.SetToolTip(lblSendTo, "Enables 'Send To' shortcut for easy file submission to VirusTotal.");
        }
        private void fmSettings_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(Width, Height);
            this.MaximumSize = this.MinimumSize;

            config = WidgetSettings.LoadSettingsFromConfigFile();
            currentApiKey = config.VirusTotalApiKey;
            txtApiKey.Text = ToggleAPIKey();

            cbAutostart.Checked = config.AutoStartEnabled;
            cbFadeEffect.Checked = config.FadeEffect;
            cbSendTo.Checked = config.SendToEnabled;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool IsAutoStartEnabled = cbAutostart.CheckState == CheckState.Checked;
            bool IsFadeEffectEnabled = cbFadeEffect.CheckState == CheckState.Checked;
            bool IsSendToEnabled = cbSendTo.CheckState == CheckState.Checked;

            WidgetSettings settings = new()
            {
                VirusTotalApiKey = ValidateAPIKey(currentApiKey, config.VirusTotalApiKey),
                LicenseAgreementAccepted = true,
                AutoStartEnabled = IsAutoStartEnabled,
                FadeEffect = IsFadeEffectEnabled,
                SendToEnabled = IsSendToEnabled,

            };

            string jsonString = JsonSerializer.Serialize(settings);
            WidgetSettings.SaveUserData(jsonString);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
        private void txtApiKey_TextChanged(object sender, EventArgs e)
        {
            if (txtApiKey.Text.Contains('*'))
                return;
            currentApiKey = txtApiKey.Text;
        }
        private void btnView_Click(object sender, EventArgs e) => txtApiKey.Text = ToggleAPIKey();

        private string ToggleAPIKey()
        {
            ShowAPIKey = !ShowAPIKey;

            if (ShowAPIKey)
                return currentApiKey;
            else
                return new string('*', 64);
        }

        private string ValidateAPIKey(string newKey, string oldKey)
        {
            if (newKey.Contains('*'))
                return oldKey;
            return newKey;
        }

  
    }
}
