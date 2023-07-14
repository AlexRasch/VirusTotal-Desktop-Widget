using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Widget
{
    public static partial class WindowsAPI
    {
        public static int CreateShortcutEX(string shortcutPath, string targetPath)
        {
            return NativeMethods.SHCreateShortcut(shortcutPath, targetPath, IntPtr.Zero, IntPtr.Zero);
        }

        internal static partial class NativeMethods
        {
            [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
            public static extern int SHCreateShortcut(
                [MarshalAs(UnmanagedType.LPWStr)] string pszShortcutFile,
                [MarshalAs(UnmanagedType.LPWStr)] string pszTargetFile,
                IntPtr pfd,
                IntPtr unused
            );
        }
    }
}
