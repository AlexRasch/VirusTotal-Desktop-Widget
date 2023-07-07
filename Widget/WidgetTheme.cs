using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget
{
    public class WidgetTheme
    {
        public string Name { get; set; }
        public string? BackgroundImage { get; set; }
        public string? BackgroundColor { get; set; }

        public static List<WidgetTheme> GetAvailableThemes()
        {
            var themes = new List<WidgetTheme>
            {
                new WidgetTheme
                {
                    Name = "Default"
                },
                new WidgetTheme
                {
                    Name = "Outrun",
                    BackgroundImage = Properties.Resources.bg_outrun.ToString(),

                },
            };

            return themes;
        }

    }
}
