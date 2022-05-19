using SpaciousStartMenu.Settings;
using SpaciousStartMenu.Shell;
using System;
using System.Windows;

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
            RemoveShortcut.IsEnabled = Shortcut.ExistsStartupShortcut(App.GetRes("AppLinkName"));

            MinimizeStartup.IsChecked = _settings.MinimizeStartup;

            EscKeyMin.IsChecked = _settings.EscKeyMinimize;
            DblClickMin.IsChecked = _settings.MarginDoubleClickMinimize;
            CtrlClickDisabledMin.IsChecked = _settings.DisabledMinimizeCtrlClick;

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
            _settings.MinimizeStartup = MinimizeStartup.IsChecked == true;

            _settings.EscKeyMinimize = EscKeyMin.IsChecked == true;
            _settings.MarginDoubleClickMinimize = DblClickMin.IsChecked == true;
            _settings.DisabledMinimizeCtrlClick = CtrlClickDisabledMin.IsChecked == true;

            _settings.ConfirmCloseMenu = ConfirmClose.IsChecked == true;

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RegShortcut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Shortcut.ExistsStartupShortcut(App.GetRes("AppLinkName")))
                {
                    RemoveStartupShortcut();
                }
                CreateStartupShortcut();
                Msg.Info(App.GetRes("MsgInfoRegStartupShortcut"));

                RegShortcut.IsEnabled = false;
                RemoveShortcut.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Msg.Error(ex.ToString());
            }
        }

        private void MinimizeStartup_Click(object sender, RoutedEventArgs e)
        {
            RegShortcut.IsEnabled = true;
        }

        private void RemoveShortcut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Shortcut.ExistsStartupShortcut(App.GetRes("AppLinkName")))
                {
                    RemoveStartupShortcut();
                    Msg.Info(App.GetRes("MsgInfoRemoveStartupShortcut"));
                }
                RegShortcut.IsEnabled = true;
                RemoveShortcut.IsEnabled = false;
            }
            catch (Exception ex)
            {
                Msg.Error(ex.ToString());
            }
        }


        private void CreateStartupShortcut()
        {
            Shortcut.CreateStartupShortcut(
                App.GetRes("AppLinkName"),
                Environment.ProcessPath!,
                MinimizeStartup.IsChecked == true);
        }

        private void RemoveStartupShortcut()
        {
            Shortcut.RemoveStartupShortcut(App.GetRes("AppLinkName"));
        }

    }
}
