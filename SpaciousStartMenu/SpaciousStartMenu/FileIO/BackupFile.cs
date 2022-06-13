using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SpaciousStartMenu.FileIO
{
    internal class BackupFile
    {
        private static readonly Regex _targetPathTail = new(@"\.bak[2-3]?$");

        public static string GetFilePath(string orginalFilePath)
        {
            string b1 = $"{orginalFilePath}.bak";
            string b2 = $"{orginalFilePath}.bak2";
            string b3 = $"{orginalFilePath}.bak3";

            if (!File.Exists(b1))
            {
                return b1;
            }
            else if (!File.Exists(b2))
            {
                return b2;
            }
            else if (!File.Exists(b3))
            {
                return b3;
            }

            var target = new DirectoryInfo(Path.GetDirectoryName(orginalFilePath)!)
                .GetFiles($"{Path.GetFileName(orginalFilePath)}*", SearchOption.TopDirectoryOnly)
                .Where(f => _targetPathTail.IsMatch(f.Name))
                .OrderBy(f => f.LastWriteTime)
                .FirstOrDefault();

            return target?.FullName ?? b1;
        }
    }
}
