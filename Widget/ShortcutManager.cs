using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
// Windows Script Host
//using IWshRuntimeLibrary;
using System.Diagnostics.Eventing.Reader;

namespace Widget
{
    //This code is commented out because it causes issues with the GitHub Action due to the COM reference.
    //We are actively working on finding an alternative solution that doesn't rely on the .NET Framework and.
    //If possible, doesn't require admin privileges....

    public class ShortcutManager
    {
        /*

        private static string ShortcutFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\SendTo");

        public static void HandleSendTo(bool sendTo, string shortcutName)
        {
            string shortcutFullPath = Path.Combine(ShortcutFolderPath, $"{shortcutName}.lnk");

            if (sendTo)
                CreateSendToShortcut(shortcutFullPath);
            else
                DeleteSendToShortcut(shortcutFullPath);
        }

        private static void CreateSendToShortcut(string shortcutFullPath)
        {
            CreateShortcut(shortcutFullPath, Constants.GetApplicationPath());
        }

        private static void DeleteSendToShortcut(string shortcutFullPath)
        {
            if (ShortcutExist(shortcutFullPath))
                System.IO.File.Delete(shortcutFullPath);
        }

        private static bool ShortcutExist(string shortcutName)
        {
            try
            {
                return System.IO.File.Exists(Path.Combine(ShortcutFolderPath, shortcutName));
      
            }
            catch
            {
#if DEBUG
                Debug.WriteLine("ShortcutManager: error checking if shortcut exist");
#endif
                throw new Exception("Error checking if shortcut exist");
            }
        }

        private static void CreateShortcut(string shortcutPath, string targetPath, string arguments = null, string workingDirectory = null)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = targetPath;
            shortcut.Arguments = arguments;
            shortcut.WorkingDirectory = workingDirectory;

            shortcut.Save();
        } */
    }
}
