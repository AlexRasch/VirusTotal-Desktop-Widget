using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Widget
{
    public static partial class WindowsAPI
    {

        public static void DragWindowsForm(IntPtr formHandle)
        {
            NativeMethods.ReleaseCapture();
            NativeMethods.SendMessage(formHandle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HTCAPTION, 0);

           
        }


        internal static partial class NativeMethods
        {
            public const int WM_NCLBUTTONDOWN = 0xA1;
            public const int HTCAPTION = 0x2;

            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImportAttribute("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImportAttribute("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool ReleaseCapture();
        }

    }
}
