using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widget;
using static Widget.WidgetConfiguration;

namespace WidgetTests
{
    public class WidgetConfigurationTests
    {
        [Fact]
        public void LoadSettingsFromConfigFile_ShouldLoadValidSettings()
        {
            // Create a sample config file with valid settings
            string configData = "" +
                "{" +
                "\"VirusTotalApiKey\": null," +
                " \"LicenseAgreementAccepted\": true," +
                " \"AutoStartEnabled\": false" +
                "}";

            System.IO.File.WriteAllText(WidgetConfiguration.widgetConfigPath, configData);

            // Act
            var settings = WidgetConfiguration.WidgetSettings.LoadSettingsFromConfigFile();

            // Assert
            Assert.NotNull(settings);
            Assert.Null(settings.VirusTotalApiKey);
            Assert.True(settings.LicenseAgreementAccepted);
            Assert.False(settings.AutoStartEnabled);
        }
    }
}
