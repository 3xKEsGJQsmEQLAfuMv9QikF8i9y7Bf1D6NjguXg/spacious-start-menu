using System;
using System.IO;

namespace SpaciousStartMenu.Shell
{
    internal class Shortcut
    {
        public static void CreateStartupShortcut(string linkName, string targetPath) => 
            CreateShortcut(
                GetStartupShortcutPath(linkName),
                targetPath);

        public static bool ExistsStartupShortcut(string linkName) =>
            File.Exists(GetStartupShortcutPath(linkName));

        public static void RemoveStartupShortcut(string linkName) =>
            File.Delete(GetStartupShortcutPath(linkName));

        private static string GetStartupShortcutPath(string linkName) =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), $"{linkName}.lnk");

        public static void CreateShortcut(string linkFilePath, string targetPath)
        {
            const int MinWindow = 7;

            var shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = shell.CreateShortcut(linkFilePath);
            shortcut.TargetPath = targetPath;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
            shortcut.WindowStyle = MinWindow;
            shortcut.Save();
        }
    }
}
