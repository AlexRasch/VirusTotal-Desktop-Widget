using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widget.Forms
{
    internal static class FormUtils
    {
        /// <summary>
        /// Performs a fade in effect on the form specified by its handle.
        /// </summary>
        /// <param name="formHandle">The handle of the form to fade in.</param>
        /// <param name="fadeDuration">The total duration, in milliseconds, for the fade in effect. Default is 1024 milliseconds.</param>
        /// <returns></returns>
        public static async Task FadeInForm(IntPtr formHandle, int fadeDuration = 1024)
        {
            try
            {
                int fadeDelay = CalculateFadeDelay(fadeDuration);
                
                // Make the window transparent and set initial opacity to 0
                WindowsAPI.MakeWindowTransparent(formHandle);
                WindowsAPI.FadeIn(formHandle, 0);

                // Fade in
                for (int opacity = 0; opacity <= 255; opacity += 1)
                {
                    await Task.Delay(fadeDelay); // Delay between opacity changes during fade
                    WindowsAPI.FadeIn(formHandle, opacity);
                }
            }
            catch {
#if DEBUG
                Debug.WriteLine($"Error occurred during FadeInForm.");
#endif
            }
        }

        /// <summary>
        /// Performs a fade out effect on the form specified by its handle.
        /// </summary>
        /// <param name="formHandle">The handle of the form to fade out.</param>
        /// <param name="fadeDuration">The total duration, in milliseconds, for the fade out effect. Default is 1024 milliseconds.</param>
        /// <returns></returns>
        public static async Task FadeOutForm(IntPtr formHandle, int fadeDuration = 1024)
        {
            try
            {
                int fadeDelay = CalculateFadeDelay(fadeDuration);

                // Make windows transparent and set initial opacity to 255
                WindowsAPI.MakeWindowTransparent(formHandle);
                WindowsAPI.FadeIn(formHandle, 255);

                // Fade out
                for (int opacity = 255; opacity >= 0; opacity -= 1)
                {
                    await Task.Delay(fadeDelay); // Delay between opacity changes during fade
                    WindowsAPI.FadeIn(formHandle, opacity);
                }
            }
            catch {
#if DEBUG
                Debug.WriteLine($"Error occurred during FadeOutForm.");
#endif
            }
        }

        /// <summary>
        /// Calculates the delay between opacity changes during form fading.
        /// </summary>
        /// <param name="delay">The total duration of the fade effect, in milliseconds.</param>
        /// <returns>The amount of time, in milliseconds, to sleep between opacity changes during the fade effect.</returns>
        private static int CalculateFadeDelay(int fadeDuration) => fadeDuration /= 256;
    }
}
