using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Widget
{
    public static partial class WindowsAPI
    {
        /// <summary>
        /// Makes the specified window transparent by setting the WS_EX_LAYERED extended window style.
        /// </summary>
        /// <param name="hWindow">Handle to the window.</param>
        public static int MakeWindowTransparent(IntPtr hWindow)
        {
            try
            {
                int previouseValue = NativeMethods.SetWindowLong(hWindow, NativeMethods.GWL_EXSTYLE, NativeMethods.GetWindowLong(hWindow, NativeMethods.GWL_EXSTYLE) | NativeMethods.WS_EX_LAYERED);
                // If the function fails, the return value is zero.
                if (previouseValue == 0)
                {
#if DEBUG
                    Debug.WriteLine($"WinAPI SetWindowLong: {Marshal.GetLastWin32Error()}");
#endif
                }

                return previouseValue;
            }
            catch
            {
                return 0;
            }
        }

        public static bool FadeOut(IntPtr hWindow, int opacity)
        {
            if (opacity < 0 || opacity > 255)
                throw new ArgumentOutOfRangeException(nameof(opacity), "Opacity value must be between 0 and 255.");
            try
            {
                bool result = Fade(hWindow, opacity);
                return result;
            }
            catch
            {
#if DEBUG
                Debug.WriteLine($"WinAPI FadeOut:");
#endif              
                return false;
            }
        }

        public static bool FadeIn(IntPtr hWindow, int opacity)
        {
            if (opacity < 0 || opacity > 255)
                throw new ArgumentOutOfRangeException(nameof(opacity), "Opacity value must be between 0 and 255.");

            try
            {
                bool result = Fade(hWindow, opacity);
                return result;
            }
            catch {
#if DEBUG
                Debug.WriteLine($"WinAPI FadeIn: ");
#endif              
                return false;
            }
        }

        /// <summary>
        /// Changes the opacity of the specified window.
        /// </summary>
        /// <param name="hWindow">The handle of the window to apply the fade effect.</param>
        /// <param name="opacity">The opacity value to set (0-255), where 0 is fully transparent and 255 is fully opaque.</param>
        /// <returns><c>true</c> if the opacity change was successful; otherwise, <c>false</c>.</returns>
        private static bool Fade(IntPtr hWindow, int opacity)
        {
            if (opacity < 0 || opacity > 255)
                throw new ArgumentOutOfRangeException(nameof(opacity), "Opacity value must be between 0 and 255.");

            try
            {
                bool result = NativeMethods.SetLayeredWindowAttributes(hWindow, 0, (byte)opacity, NativeMethods.LWA_ALPHA);
                return result;
            }
            catch
            {
#if DEBUG
                Debug.WriteLine($"WinAPI SetLayeredWindowAttributes: {Marshal.GetLastWin32Error()}");
#endif              
                return false;
            }
        }

        public static void DragWindowsForm(IntPtr formHandle)
        {
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(formHandle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HTCAPTION, 0);
        }


        internal static partial class NativeMethods
        {
            /* Drag Widget / Application */

            public const int WM_NCLBUTTONDOWN = 0xA1;
            public const int HTCAPTION = 0x2;

            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImportAttribute("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImportAttribute("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool ReleaseCapture();

            // Fade in
            public const int GWL_EXSTYLE = -20;
            public const int WS_EX_LAYERED = 0x80000; // 65536
            public const uint LWA_ALPHA = 0x2;
            public const int FADE_DURATION = 500;

            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImport("user32.dll", SetLastError = true)]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImport("user32.dll", SetLastError = true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        }

    }
}
