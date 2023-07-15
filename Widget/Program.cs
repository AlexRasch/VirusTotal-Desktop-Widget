using System.Threading;
using System;
using System.Diagnostics;
using static Widget.WidgetConfiguration;
using VirusTotal;
using System.Windows.Forms;

namespace Widget
{
    internal static class Program
    {

        public static Mutex mutex = new(true, $"{WidgetConfiguration.widgetMutex}", out isFirstInstance);
        private static bool isFirstInstance;

        [STAThread]
        static void Main(string[] args)
        {
            // Send to
            if (args.Length >= 1)
            {
                Task.Run(() => HandleCommandLineArguments(args)).Wait();
                Environment.Exit(0);
            }

            // Normal application start
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
                TaskScheduler.UnobservedTaskException += HandleUnobservedTaskException;

                ApplicationConfiguration.Initialize();
                frmWidget mainForm = new();
                Application.Run(mainForm);
            }
            finally
            {
                mutex.ReleaseMutex();
                mutex.Dispose();
            }
        }


        private static async Task HandleCommandLineArguments(string[] args)
        {
            // If there are command line arguments, the app is most likely called from the context menu "Send to"
            // ToDo: This logic is very similar to the one in fmWidget.
            // Consider finding a better approach to adhere to the "Don't Repeat Yourself" (DRY) principle and avoid code duplication.

            string fileToSubmitPath = args[0];
            WidgetSettings widgetSettings = WidgetSettings.LoadSettingsFromConfigFile();

            // Do we have a API key?
            if (string.IsNullOrWhiteSpace(widgetSettings.VirusTotalApiKey))
            {
                MessageBox.Show("Missing VirusTotal API key", "Error");
                return;
            }
            VT vt = new(widgetSettings.VirusTotalApiKey);

            // Scan file
            ResponseParser vtReponse = new();
            vtReponse = await vt.ScanFileAsync(vt, fileToSubmitPath);
            // Handle API error
            if (vtReponse.ErrorCode != null)
            {
                MessageBox.Show($"Error:{vtReponse.ErrorCode.Code}", "API issues");
                return;
            }
            // Display report
            using fmVTScanResult scanResult = new(vtReponse);
            scanResult.ShowDialog();

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