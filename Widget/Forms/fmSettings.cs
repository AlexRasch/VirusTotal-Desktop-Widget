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
        private List<WidgetTheme> themes = WidgetTheme.GetAvailableThemes();

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

            WidgetSettings settings = new WidgetSettings
            {
                VirusTotalApiKey = apiKey,
                LicenseAgreementAccepted = true,
                AutoStartEnabled = IsAutoStartEnabled,
                widgetTheme = GetThemeFromComboBox(),

        };

            string jsonString = JsonSerializer.Serialize(settings);
            WidgetSettings.SaveUserData(jsonString);

        }

        private void fmSettings_Load(object sender, EventArgs e)
        {
            config = WidgetSettings.LoadSettingsFromConfigFile();
            txtApiKey.Text = config.VirusTotalApiKey;
            cbAutostart.Checked = config.AutoStartEnabled;

            // Load themes
            InitializeThemeComboBox();
        }

        private void InitializeThemeComboBox()
        {
            // Clear existing items and add themes to the ComboBox
            cmbTheme.Items.Clear();
            foreach (var theme in themes)
            {
                cmbTheme.Items.Add(theme.Name);
            }

            // Set the default selected theme
            cmbTheme.SelectedItem = GetSelectedThemeFromSettings();
        }

        private WidgetTheme GetThemeFromComboBox()
        {
            string themeName = this.cmbTheme.GetItemText(this.cmbTheme.SelectedItem);
            foreach (var theme in themes)
            {
                if(theme.Name == themeName)
                    return theme;
            }
            return null;

        }

        private string GetSelectedThemeFromSettings()
        {
            if(config.widgetTheme == null)
            {
                return "Default";
            }
            else
            {
                return config.widgetTheme.Name;
            }
            
        }

    }
}
