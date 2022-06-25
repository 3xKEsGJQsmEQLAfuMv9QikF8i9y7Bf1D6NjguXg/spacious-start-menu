using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SpaciousStartMenu.Shell
{
    internal class ShellExecution
    {
        private static readonly Regex _specialFolder = new("<(.+?)>");
        private static readonly Regex _envFolder = new("<ENV:(.+?)>");

        public static void Run(string cmd, string? workDir, string? args)
        {
            var p = new Process();
            p.StartInfo.FileName = ReplaceSpecialFolder(cmd);
            if (!string.IsNullOrWhiteSpace(workDir))
            {
                p.StartInfo.WorkingDirectory = ReplaceSpecialFolder(workDir);
            }
            if (!string.IsNullOrWhiteSpace(args))
            {
                p.StartInfo.Arguments = args;
            }
            p.StartInfo.UseShellExecute = true;

            p.Start();
        }

        private static string ReplaceSpecialFolder(string path)
        {
            const string pattern = "<(.+?)>";

            return Regex.Replace(path, pattern, MatchEvaluator);
        }

        private static string MatchEvaluator(Match m)
        {
            const string envMark = "ENV:";
            if (m.Groups[1].Value.StartsWith(envMark, StringComparison.OrdinalIgnoreCase))
            {
                string? env = Environment.GetEnvironmentVariable(
                    m.Groups[1].Value[envMark.Length..]);
                if (!string.IsNullOrEmpty(env))
                {
                    return env;
                }
            }
            else
            {
                if (Enum.TryParse(m.Groups[1].Value, out Environment.SpecialFolder sf))
                {
                    return Environment.GetFolderPath(sf);
                }
            }

            return m.Value;
        }
    }
}
