using System.Diagnostics;

namespace SpaciousStartMenu.Shell
{
    internal class ShellExecution
    {
        public static void Run(string cmd)
        {
            var p = new Process();
            p.StartInfo.FileName = cmd;
            p.StartInfo.UseShellExecute = true;

            p.Start();
        }
    }
}
