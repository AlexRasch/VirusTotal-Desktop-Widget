using System.Threading;
using System;
using System.Diagnostics;

namespace Widget
{
    internal static class Program
    {

        public static Mutex mutex = new(true, $"{WidgetConfiguration.widgetMutex}", out isFirstInstance);
        private static bool isFirstInstance;

        [STAThread]
        static void Main(string[] args)
        {
            // If args the app is 99% called from send to context

            // Send file and show report

            // Shutdown instance

            if (!isFirstInstance)
            {
                WindowsAPI.BringExistingInstanceToFront();
                ShowAlreadyRunningMessage();
                return;
            }
            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += HandleThreadException;
                AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;

                ApplicationConfiguration.Initialize();
                frmWidget mainForm = new ();
                Application.Run(mainForm);
            }
            finally
            {
                mutex.ReleaseMutex();
                mutex.Dispose();
            }
        }

        private static void ShowAlreadyRunningMessage()
        {
            MessageBox.Show("Widget is already running.\n\n" +
                            "Please close the existing instance before launching a new one.\n",
                            "Widget already running");
        }

        private static void HandleThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
#if DEBUG
            Debug.WriteLine($"ThreadException: {e}");
#endif
        }

        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
#if DEBUG
            if (e.ExceptionObject is Exception exception)
            {
                string exceptionMessage = exception.Message;
                Debug.WriteLine($"UnhandledException: {exceptionMessage} ({e})");
            }
            else
            {
                Debug.WriteLine($"UnhandledException: ({e.ToString()})");
            }
#endif
        }
    }
}