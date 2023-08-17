using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Widget
{
    public static partial class WindowsAPI
    {
        public static bool RunningFullScreenApp()
        {
            return NativeMethods.FullScreenRunning();
        }

        internal static partial class NativeMethods
        {
            public struct UserNotificationState
            {
                public int State;
            }

            [DllImport("shell32.dll")]
            static extern int SHQueryUserNotificationState(out UserNotificationState state);

            public static bool FullScreenRunning()
            {
                UserNotificationState userNotificationState;
                var returnVal = SHQueryUserNotificationState(out userNotificationState);
                return userNotificationState.State == 3;
            }
        }
    }
}
