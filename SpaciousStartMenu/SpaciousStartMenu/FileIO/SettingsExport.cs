using System;
using System.IO;
using System.Text;

namespace SpaciousStartMenu.FileIO
{
    internal class SettingsExport
    {
        private static readonly UTF8Encoding _utf8withBOM = new(encoderShouldEmitUTF8Identifier: true);
        private static readonly UTF8Encoding _utf8 = new(encoderShouldEmitUTF8Identifier: false);

        public static void Export(
            string appVersion,
            string runtimeVersion,
            string launcherDefinePath,
            string settingsFilePath,
            string backupFilePath)
        {
            var d = DateTime.Now;

            using var sw = new StreamWriter(backupFilePath, append: false, encoding: _utf8withBOM);

            using var sr1 = new StreamReader(
                new FileStream(launcherDefinePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite),
                _utf8withBOM);

            sw.WriteLine(
                $"# Spacious Start Menu v{appVersion}(Runtime v{runtimeVersion}) Settings {d.Year:D4}-{d.Month:D2}-{d.Day:D2} {d.Hour:D2}:{d.Minute:D2}:{d.Second:D2} Backup");
            while (!sr1.EndOfStream)
            {
                sw.WriteLine(sr1.ReadLine());
            }

            sw.WriteLine("################################################################################");

            using var sr2 = new StreamReader(
                new FileStream(settingsFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite),
                _utf8);
            while (!sr2.EndOfStream)
            {
                sw.WriteLine(sr2.ReadLine());
            }

        }
    }
}
