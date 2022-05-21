using System.Windows;

namespace SpaciousStartMenu.Views
{
    internal class Msg
    {
        public static void Error(string msg) =>
            MessageBox.Show(msg, App.GetRes("R_Error"), MessageBoxButton.OK, MessageBoxImage.Error);

        public static void Info(string msg) =>
            MessageBox.Show(msg, App.GetRes("R_Info"), MessageBoxButton.OK, MessageBoxImage.Information);

        public static MessageBoxResult Confirm(string msg) =>
            MessageBox.Show(
                msg, App.GetRes("R_Confirm"), MessageBoxButton.YesNo, MessageBoxImage.Question);

    }
}
