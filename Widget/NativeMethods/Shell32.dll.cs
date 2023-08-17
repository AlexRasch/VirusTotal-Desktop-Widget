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
                /// <summary>
                /// A screen saver is displayed, the machine is locked, or a nonactive Fast User Switching session is in progress.
                /// </summary>
                public bool QUNS_NOT_PRESENT => State == 0;

                public bool IsFullScreenRunning => State == 3;
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
