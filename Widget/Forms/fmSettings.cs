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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string apiKey = txtApiKey.Text;
            bool IsAutoStartEnabled = cbAutostart.CheckState == CheckState.Checked;
            bool IsFadeEffectEnabled = cbFadeEffect.CheckState == CheckState.Checked;
            bool IsSendToEnabled = cbSendTo.CheckState == CheckState.Checked;

            WidgetSettings settings = new()
            {
                VirusTotalApiKey = apiKey,
                LicenseAgreementAccepted = true,
                AutoStartEnabled = IsAutoStartEnabled,
                FadeEffect = IsFadeEffectEnabled,
                SendToEnabled = IsSendToEnabled,

            };

            string jsonString = JsonSerializer.Serialize(settings);
            WidgetSettings.SaveUserData(jsonString);

        }

        private void fmSettings_Load(object sender, EventArgs e)
        {
            config = WidgetSettings.LoadSettingsFromConfigFile();
            txtApiKey.Text = config.VirusTotalApiKey;

            cbAutostart.Checked = config.AutoStartEnabled;
            cbFadeEffect.Checked = config.FadeEffect;
            cbSendTo.Checked = config.SendToEnabled;
            //cbSendTo.Checked = false;
        }
    }
}
