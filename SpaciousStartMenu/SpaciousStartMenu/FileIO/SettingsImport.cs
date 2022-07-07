using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaciousStartMenu.FileIO
{
    internal class SettingsImport
    {
        private static readonly UTF8Encoding _utf8withBOM = new(encoderShouldEmitUTF8Identifier: true);
        private static readonly UTF8Encoding _utf8 = new(encoderShouldEmitUTF8Identifier: false);

        public static async Task ImportAsync(
            string importFilePath,
            string launcherDefinePath,
            string settingsFilePath)
        {
            using var sr = new StreamReader(importFilePath, _utf8withBOM);

            using var sw1 = new StreamWriter(launcherDefinePath, append: false, encoding: _utf8withBOM);
            using var sw2 = new StreamWriter(settingsFilePath, append: false, encoding: _utf8);

            int lineCnt = 0;
            bool isLaunchDefinePart = true;
            while (!sr.EndOfStream)
            {
                string? line = await sr.ReadLineAsync();
                if (line is null)
                {
                    continue;
                }
                lineCnt++;

                if (lineCnt == 1)
                {
                    if (!line.StartsWith("# Spacious Start Menu"))
                    {
                        throw new FormatException(App.R("MsgErrInvalidFileNoHeader"));
                    }
                    continue;
                }

                if (line.StartsWith("##########"))
                {
                    isLaunchDefinePart = false;
                    continue;
                }

                if (isLaunchDefinePart)
                {
                    await sw1.WriteLineAsync(line);
                }
                else
                {
                    await sw2.WriteLineAsync(line);
                }
            }

            if (isLaunchDefinePart)
            {
                throw new FormatException(App.R("MsgErrInvalidFileNoDelimiter"));
            }
        }

        public static void Backup(string filePath1, string filePath2)
        {
            FileCopy(filePath1, $"{filePath1}.tmp");
            FileCopy(filePath2, $"{filePath2}.tmp");
        }

        public static void Restore(string filePath1, string filePath2)
        {
            FileCopy($"{filePath1}.tmp", filePath1);
            FileCopy($"{filePath2}.tmp", filePath2);
        }

        private static void FileCopy(string from, string to)
        {
            if (File.Exists(from))
            {
                File.Copy(from, to, overwrite: true);
            }
        }
    }
}
