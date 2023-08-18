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
using Widget.Forms;
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

            System.Windows.Forms.ToolTip toolTipThreshold = new();
            toolTipThreshold.SetToolTip(lblThreshold, Constants.ThresholdToolTip);

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (config.FadeEffect)
                _ = FormUtils.FadeInForm(Handle, 256);
        }

        private void fmSettings_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(Width, Height);
            this.MaximumSize = this.MinimumSize;

            config = WidgetSettings.LoadSettingsFromConfigFile();
            currentApiKey = config.VirusTotalApiKey ?? "";

            if (string.IsNullOrEmpty(currentApiKey))
                currentApiKey = "";

            txtApiKey.Text = ToggleAPIKey();

            cbAutostart.Checked = config.AutoStartEnabled;
            cbFadeEffect.Checked = config.FadeEffect;
            cbSendTo.Checked = config.SendToEnabled;
            cbOptimizePerformance.Checked = config.OptimizePerformance;

            // Get values for combobox
            SetComboBoxValue(cbbThreshold, config.SystemUsageThreshold);
            SetComboBoxValue(cbbUpdateInterval, config.SystemUsageUpdateInterval);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            bool IsAutoStartEnabled = cbAutostart.CheckState == CheckState.Checked;
            bool IsFadeEffectEnabled = cbFadeEffect.CheckState == CheckState.Checked;
            bool IsSendToEnabled = cbSendTo.CheckState == CheckState.Checked;
            bool IsOptimizePerformanceEnabled = cbOptimizePerformance.CheckState == CheckState.Checked;


            if (currentApiKey.Length < 1 && currentApiKey.Length > 64)
            {
                MessageBox.Show("Invalid API key length", "API key issues");
                return;
            }


            WidgetSettings settings = new()
            {
                VirusTotalApiKey = ValidateAPIKey(currentApiKey, config.VirusTotalApiKey),
                LicenseAgreementAccepted = true,
                AutoStartEnabled = IsAutoStartEnabled,
                FadeEffect = IsFadeEffectEnabled,
                SendToEnabled = IsSendToEnabled,
                SystemUsageThreshold = config.SystemUsageThreshold,
                SystemUsageUpdateInterval = config.SystemUsageUpdateInterval,
                OptimizePerformance = IsOptimizePerformanceEnabled,

            };

            string jsonString = JsonSerializer.Serialize(settings);
            WidgetSettings.SaveUserData(jsonString);

            if (config.FadeEffect)
                await FormUtils.FadeOutForm(Handle, 256);

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

        private void SetComboBoxValue(ComboBox comboBox, int valueToMatch)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (Convert.ToInt32(comboBox.Items[i]) == valueToMatch)
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }


        private string ToggleAPIKey()
        {
            ShowAPIKey = !ShowAPIKey;

            // Toggle btnView text
            ToggleBtnViewText();

            if (ShowAPIKey)
                return currentApiKey;
            else
                return new string('*', currentApiKey.Length);
        }

        private void ToggleBtnViewText()
        {
            if (ShowAPIKey)
                btnView.Text = "View";
            else
                btnView.Text = "Hide";
        }

        private string ValidateAPIKey(string newKey, string oldKey)
        {
            if (newKey.Contains('*'))
                return oldKey;
            return newKey;
        }

        private void cbbThreshold_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex != -1) // -1 means no selection
            {
                config.SystemUsageThreshold = Convert.ToInt32(comboBox.SelectedItem);
            }
        }

        private void cbbUpdateInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex != -1) // -1 means no selection
            {
                config.SystemUsageUpdateInterval = Convert.ToInt32(comboBox.SelectedItem);
            }
        }
    }
}
