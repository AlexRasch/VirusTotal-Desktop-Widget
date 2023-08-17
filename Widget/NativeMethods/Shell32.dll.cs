﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Widget
{
    public static partial class WindowsAPI
    {
        public static bool IsUserEngagedInFullScreenActivity()
        {
            return NativeMethods.CheckNotificationState();
        }

        internal static partial class NativeMethods
        {
            // https://learn.microsoft.com/en-us/windows/win32/api/shellapi/ne-shellapi-query_user_notification_state

            public struct UserNotificationState
            {
                public int State;
                /// <summary>
                /// A screen saver is displayed, the machine is locked, or a nonactive Fast User Switching session is in progress.
                /// </summary>
                public bool QUNS_NOT_PRESENT => State == 1;
                /// <summary>
                /// A full-screen application is running or Presentation Settings are applied. 
                /// Presentation Settings allow a user to put their machine into a state fit for an uninterrupted presentation,
                /// such as a set of PowerPoint slides, with a single click.
                /// </summary>
                public bool QUNS_BUSY => State == 2;

                /// <summary>
                /// A full-screen (exclusive mode) Direct3D application is running.
                /// </summary>
                public bool QUNS_RUNNING_D3D_FULL_SCREEN => State == 3;

                /// <summary>
                /// The user has activated Windows presentation settings to block notifications and pop-up messages.
                /// </summary>
                public bool QUNS_PRESENTATION_MODE => State == 4;

                /// <summary>
                /// None of the other states are found, notifications can be freely sent.
                /// </summary>
                public bool QUNS_ACCEPTS_NOTIFICATIONS => State == 5;

                public bool QUNS_QUIET_TIME => State == 6;

                /// <summary>
                /// A Windows Store app is running.
                /// </summary>
                public bool QUNS_APP => State == 7;

                /// <summary>
                /// Checks if state is ....
                /// </summary>
                public bool IsFullScreenRunning => State == 3 || State == 2;
            }

            [DllImport("shell32.dll")]
            static extern int SHQueryUserNotificationState(out UserNotificationState state);

            public static bool CheckNotificationState()
            {
                UserNotificationState userNotificationState;
                var returnVal = SHQueryUserNotificationState(out userNotificationState);
                return userNotificationState.IsFullScreenRunning;
            }
        }
    }
}
