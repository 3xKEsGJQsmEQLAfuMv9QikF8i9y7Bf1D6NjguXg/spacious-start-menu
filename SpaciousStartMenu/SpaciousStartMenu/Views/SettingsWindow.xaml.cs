using SpaciousStartMenu.Settings;
using SpaciousStartMenu.Shell;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SpaciousStartMenu.Views
{
    public partial class SettingsWindow : Window
    {
        private readonly AppSettings _settings;

        public SettingsWindow(AppSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RegStartup.IsChecked = Shortcut.ExistsStartupShortcut(App.GetRes("AppLinkName"));
            EscKeyMinimize.IsChecked = _settings.EscKeyMinimize;
            DblClickMinimize.IsChecked = _settings.MarginDoubleClickMinimize;
            ConfirmClose.IsChecked = _settings.ConfirmCloseMenu;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            _settings.RegStartupShortcut = RegStartup.IsChecked == true;
            _settings.EscKeyMinimize = EscKeyMinimize.IsChecked == true;
            _settings.MarginDoubleClickMinimize = DblClickMinimize.IsChecked == true;
            _settings.ConfirmCloseMenu = ConfirmClose.IsChecked == true;

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegStartup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not CheckBox chk)
            {
                return;
            }

            try
            {
                if (chk.IsChecked == true)
                {
                    CreateStartupShortcut();
                }
                else
                {
                    if (!RemoveStartupShortcut())
                    {
                        chk.IsChecked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Msg.Error(ex.ToString());
            }
        }

        private void CreateStartupShortcut()
        {
            Shortcut.CreateStartupShortcut(App.GetRes("AppLinkName"), Environment.ProcessPath!);
            Msg.Info(App.GetRes("MsgInfoRegStartupShortcut"));
        }

        private bool RemoveStartupShortcut()
        {
            if (Shortcut.ExistsStartupShortcut(App.GetRes("AppLinkName")))
            {
                if (Msg.Confirm(App.GetRes("MsgConfirmRemoveStartupShortcut")) == MessageBoxResult.Yes)
                {
                    Shortcut.RemoveStartupShortcut(App.GetRes("AppLinkName"));
                    Msg.Info(App.GetRes("MsgInfoRemoveStartupShortcut"));
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
}
