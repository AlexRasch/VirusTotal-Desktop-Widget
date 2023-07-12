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
    public partial class fmSettings : Form
    {
        WidgetSettings config = new WidgetSettings();

        public fmSettings()
        {
            InitializeComponent();

            // UX
            System.Windows.Forms.ToolTip toolTipAutoStart = new System.Windows.Forms.ToolTip();
            toolTipAutoStart.SetToolTip(lblAutoStart, "Enable autostart to launch the widget automatically during Windows startup.");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string apiKey = txtApiKey.Text;
            bool IsAutoStartEnabled = cbAutostart.CheckState == CheckState.Checked;
            bool IsFadeEffectEnabled = cbFadeEffect.CheckState == CheckState.Checked;

            WidgetSettings settings = new WidgetSettings
            {
                VirusTotalApiKey = apiKey,
                LicenseAgreementAccepted = true,
                AutoStartEnabled = IsAutoStartEnabled,
                FadeEffect = IsFadeEffectEnabled,

            };

            string jsonString = JsonSerializer.Serialize(settings);
            WidgetSettings.SaveUserData(jsonString);

        }

        private void fmSettings_Load(object sender, EventArgs e)
        {
            config = WidgetSettings.LoadSettingsFromConfigFile();
            txtApiKey.Text = config.VirusTotalApiKey;
            cbAutostart.Checked = config.AutoStartEnabled;
        }
    }
}
