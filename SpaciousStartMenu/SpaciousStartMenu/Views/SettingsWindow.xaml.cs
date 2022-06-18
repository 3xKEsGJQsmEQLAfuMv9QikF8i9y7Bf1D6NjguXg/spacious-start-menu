using SpaciousStartMenu.Extensions;
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
            RestoreWindowSize(_settings);
        }

        private void RestoreWindowSize(AppSettings stg)
        {
            if (stg.SaveScreenSize)
            {
                this.SetWindowSize(
                    stg.SettingsScreenHeight,
                    stg.SettingsScreenWidth);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RemoveShortcut.IsEnabled = Shortcut.ExistsStartupShortcut(App.R("R_AppLinkName"));

            MinimizeStartup.IsChecked = _settings.MinimizeStartup;

            EscKeyMin.IsChecked = _settings.EscKeyMinimize;
            DblClickMin.IsChecked = _settings.MarginDoubleClickMinimize;
            CtrlClickDisabledMin.IsChecked = _settings.DisabledMinimizeCtrlClick;

            ConfirmClose.IsChecked = _settings.ConfirmCloseMenu;

            ShowOpenAndExitMenuItem.IsChecked = _settings.ShowOpenAndExitMenuItem;

            SaveScreenSize.IsChecked = _settings.SaveScreenSize;
            SaveScreenPos.IsChecked = _settings.SaveScreenPosition;

            ShowDirectEditDefine.IsChecked = _settings.ShowDirectEditDefineButton;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveWindowSize(_settings);
        }

        private void SaveWindowSize(AppSettings stg)
        {
            if (stg.SaveScreenSize)
            {
                stg.SettingsScreenHeight = Height;
                stg.SettingsScreenWidth = Width;
            }
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

            _settings.ShowOpenAndExitMenuItem = ShowOpenAndExitMenuItem.IsChecked == true;

            _settings.SaveScreenSize = SaveScreenSize.IsChecked == true;
            _settings.SaveScreenPosition = SaveScreenPos.IsChecked == true;

            _settings.ShowDirectEditDefineButton = ShowDirectEditDefine.IsChecked == true;

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
                if (Shortcut.ExistsStartupShortcut(App.R("R_AppLinkName")))
                {
                    RemoveStartupShortcut();
                }
                CreateStartupShortcut();
                this.Info(App.R("MsgInfoRegStartupShortcut"));

                RegShortcut.IsEnabled = false;
                RemoveShortcut.IsEnabled = true;
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
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
                if (Shortcut.ExistsStartupShortcut(App.R("R_AppLinkName")))
                {
                    RemoveStartupShortcut();
                    this.Info(App.R("MsgInfoRemoveStartupShortcut"));
                }
                RegShortcut.IsEnabled = true;
                RemoveShortcut.IsEnabled = false;
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }


        private void CreateStartupShortcut()
        {
            Shortcut.CreateStartupShortcut(
                App.R("R_AppLinkName"),
                Environment.ProcessPath!,
                MinimizeStartup.IsChecked == true);
        }

        private void RemoveStartupShortcut()
        {
            Shortcut.RemoveStartupShortcut(App.R("R_AppLinkName"));
        }

    }
}
