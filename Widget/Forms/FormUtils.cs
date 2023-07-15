using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget.Forms
{
    internal static class FormUtils
    {
        public static async Task FadeInForm(Form form)
        {
            // Make the window transparent and set initial opacity to 0
            WindowsAPI.MakeWindowTransparent(form.Handle);
            WindowsAPI.FadeIn(form.Handle, 0);

            // Fade in
            for (int opacity = 0; opacity <= 255; opacity += 1)
            {
                await Task.Delay(4);  // 256 * 4 = 1024
                form.Invoke((Action)(() => { WindowsAPI.FadeIn(form.Handle, opacity); }));
            }
        }

        public static async Task FadeOutForm(Form form)
        {
            // Make windows transparent and set initial opacity to 255
            WindowsAPI.MakeWindowTransparent(form.Handle);
            WindowsAPI.FadeIn(form.Handle, 255);

            // Fade out
            for (int opacity = 255; opacity >= 0; opacity -= 1)
            {
                await Task.Delay(4);  // 256 * 4 = 1024
                form.Invoke((Action)(() => { WindowsAPI.FadeIn(form.Handle, opacity); }));
            }
        }
    }
}
