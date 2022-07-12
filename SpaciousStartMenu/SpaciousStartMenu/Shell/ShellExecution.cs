using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SpaciousStartMenu.Shell
{
    internal class ShellExecution
    {
        public static void Run(string cmd, string? workDir, string? args, bool isAdmin = false)
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
            if (isAdmin)
            {
                p.StartInfo.Verb = "RunAs";
            }
            p.StartInfo.UseShellExecute = true;

            p.Start();
        }

        public static void RunCommand(string cmd, string? args)
        {
            var psi = new ProcessStartInfo
            {
                FileName = cmd,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            if (!string.IsNullOrEmpty(args))
            {
                psi.Arguments = args;
            }
            Process.Start(psi);
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
