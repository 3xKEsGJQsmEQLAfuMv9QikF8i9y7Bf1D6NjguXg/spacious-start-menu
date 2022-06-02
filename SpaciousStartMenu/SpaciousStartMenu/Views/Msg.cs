using System.Windows;

namespace SpaciousStartMenu.Views
{
    internal static class MsgExtensions
    {
        public static void Error(this Window owner, string msg) =>
            MsgBox.Error(owner, msg);

        public static void Info(this Window owner, string msg) =>
            MsgBox.Info(owner, msg);

        public static MessageBoxResult Confirm(this Window owner, string msg) =>
            MsgBox.Confirm(owner, msg);

        public static MessageBoxResult Confirm3Buttons(this Window owner, string msg) =>
            MsgBox.Confirm3Buttons(owner, msg);
    }
}
