using SpaciousStartMenu.Shell;

namespace SpaciousStartMenu.Win32
{
    internal static class OperatingSystem
    {
        public static void Signout() => RunShutdownCmd("/l");
        public static void Shutdown() => RunShutdownCmd("/s /t 0");
        public static void Restart() => RunShutdownCmd("/r /t 0");
        
        private static void RunShutdownCmd(string args) =>
            ShellExecution.RunCommand("shutdown.exe", args);
    }
}
