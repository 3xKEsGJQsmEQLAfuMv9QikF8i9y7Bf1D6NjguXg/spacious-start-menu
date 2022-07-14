using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SpaciousStartMenu.Shell
{
    internal class Shortcut
    {
        public static void CreateStartupShortcut(string linkName, string targetPath, bool minOption) => 
            CreateShortcut(
                GetStartupShortcutPath(linkName),
                targetPath,
                minOption);

        public static bool ExistsStartupShortcut(string linkName) =>
            File.Exists(GetStartupShortcutPath(linkName));

        public static void RemoveStartupShortcut(string linkName) =>
            File.Delete(GetStartupShortcutPath(linkName));

        private static string GetStartupShortcutPath(string linkName) =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), $"{linkName}.lnk");

        public static void CreateShortcut(string linkFilePath, string targetPath, bool minOption)
        {
            var shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = shell.CreateShortcut(linkFilePath);
            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
            if (minOption)
            {
                shortcut.Arguments = "/min";
            }
            shortcut.Save();

            if (shortcut is not null)
            {
                Marshal.ReleaseComObject(shortcut);
            }
            if (shell is not null)
            {
                Marshal.ReleaseComObject(shell);
            }
        }
    }
}
