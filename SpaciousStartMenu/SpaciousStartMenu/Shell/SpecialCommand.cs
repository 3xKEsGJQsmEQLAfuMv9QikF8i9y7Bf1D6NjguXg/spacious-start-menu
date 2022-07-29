using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace SpaciousStartMenu.Shell
{
    public enum SpecialCommandType
    {
        None,

        System_Shutdown,
        System_Restart,
        System_Signout,

        App_Minimized,
        App_ScrollToTop,
        App_ScrollToBottom,

        Desktop_Show,

        Settings_Show,

        Explorer_CloseAllFolders,

        Info_LaunchButtonCount,
        Info_GroupTitleCount,
    }

    internal static class SpecialCommand
    {
        private const string _cmdMark = "CMD:";
        private const string _cmdHead = $"<{_cmdMark}";
        private static readonly Guid _explorerId = new("{9BA05972-F6A8-11CF-A442-00A0C90A8F39}");

        public static bool IsCommand(string value)
        {
            return value.StartsWith(_cmdHead, StringComparison.OrdinalIgnoreCase);
        }

        public static SpecialCommandType GetType(string value)
        {
            if (Enum.TryParse(TrimTag(value), out SpecialCommandType sct))
            {
                return sct;
            }

            return SpecialCommandType.None;
        }

        private static string TrimTag(string cmd)
        {
            const string pattern = "<(.+?)>";

            return Regex.Replace(cmd, pattern, MatchEvaluator);
        }

        private static string MatchEvaluator(Match m)
        {
            return m.Groups[1].Value[_cmdMark.Length..] ?? "";
        }

        public static void ShowDesktop()
        {
            var shell = new Shell32.Shell();
            shell.ToggleDesktop();
            Marshal.ReleaseComObject(shell);
            shell = null;
        }

        /// <summary>
        /// Close all Explorer folders
        /// </summary>
        /// <seealso href="http://bbs.wankuma.com/index.cgi?mode=al2&namber=88492&KLOG=153">Reference article</seealso>
        public static void CloseAllFolders()
        {
            const int success = 0;
            const int retryCnt = 5;

            try
            {
                var id = Type.GetTypeFromCLSID(_explorerId);
                if (id is null)
                {
                    return;
                }
                Type t = id!;

                for (int i = 0; i < retryCnt; i++)
                {
                    dynamic? exp = Activator.CreateInstance(t);
                    if (exp is null)
                    {
                        continue;
                    }
                    System.Runtime.InteropServices.ComTypes.IEnumVARIANT it = exp._NewEnum;
                    var rgVar = new object[1];

                    int closedCnt = 0;
                    while (it.Next(1, rgVar, IntPtr.Zero) == success)
                    {
                        dynamic wnd = rgVar[0];
                        if (wnd != null)
                        {
                            if (string.Compare(Path.GetFileName(wnd.FullName), "explorer.exe", ignoreCase: true) == 0)
                            {
                                closedCnt++;
                                wnd.Quit();
                            }
                            Marshal.ReleaseComObject(wnd);
                        }
                    }

                    Marshal.ReleaseComObject(it);
                    Marshal.ReleaseComObject(exp);

                    if (closedCnt == 0)
                    {
                        break;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
