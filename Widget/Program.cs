using System.Threading;
using System;
using System.Diagnostics;
using static Widget.WidgetConfiguration;
using VirusTotal;
using System.Windows.Forms;
using Widget.Forms;

namespace Widget
{
    internal static class Program
    {

        public static Mutex mutex = new(true, $"{WidgetConfiguration.widgetMutex}", out isFirstInstance);
        private static bool isFirstInstance;

        [STAThread]
        static void Main(string[] args)
        {

            // Normal application start and no args passed to application
            if (!isFirstInstance && args.Length == 0)
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
                TaskScheduler.UnobservedTaskException += HandleUnobservedTaskException;
                // "Send to" start
                if(args.Length >= 1)
                {
                    WidgetSettings widgetSettings = new();
                    widgetSettings = WidgetSettings.LoadSettingsFromConfigFile();

                    // Do we have a API key?
                    if (string.IsNullOrWhiteSpace(widgetSettings.VirusTotalApiKey))
                    {
                        MessageBox.Show("Missing VirusTotal API key", "Error");
                        return;
                    }

                    ApplicationConfiguration.Initialize();
                    fmVTScanResult scanForm = new(args[0], widgetSettings.VirusTotalApiKey);
                    Application.Run(scanForm);
                }
                else // Normal start
                {
                    ApplicationConfiguration.Initialize();
                    frmWidget mainForm = new();
                    Application.Run(mainForm);
                }

            }
            finally
            {
                mutex.ReleaseMutex();
                mutex.Dispose();
            }
        }

        private static void ShowAlreadyRunningMessage() => MessageBox.Show(Constants.AlreadyRunningMessage, Constants.AlreadyRunningMessageTitle);

        private static void HandleThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ShowExceptionMessageBox(e.Exception);
        }
        private static void HandleUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            ShowExceptionMessageBox(e.Exception);
        }

        private static void ShowExceptionMessageBox(Exception exception)
        {
            MessageBox.Show($"{exception}", "Exception");
        }

        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            if (e.ExceptionObject is Exception exception)
            {
                string exceptionMessage = exception.Message;
                MessageBox.Show($"HandleUnhandledException: {exceptionMessage} ({e})");
            }
            else
            {
                MessageBox.Show($"HandleUnhandledException: ({e})");
            }

        }
    }
}