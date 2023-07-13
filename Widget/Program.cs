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
        static async Task Main(string[] args)
        {
            // 
            if (args.Length >= 1)
            {
                await HandleCommandLineArguments(args);
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
            // If args the app is 99% called from send to context
            // ToDo this is pretty much a copy paste of the same logic as fmWidget have
            // A better approach should be possible (thinking about Dont Repeat You're self)

            string fileToSubmitPath = args[0];
            WidgetSettings widgetSettings = WidgetSettings.LoadSettingsFromConfigFile();

            // Do we have a API key?
            if (widgetSettings.VirusTotalApiKey == null)
            {
                MessageBox.Show("Missing VirusTotal API key", "Error");
                Environment.Exit(0);
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
            using (fmVTScanResult scanResult = new(vtReponse))
            {
                scanResult.ShowDialog();

            }
            Environment.Exit(0);

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