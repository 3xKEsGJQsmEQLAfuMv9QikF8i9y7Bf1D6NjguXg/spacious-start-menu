using SpaciousStartMenu.Extensions;
using SpaciousStartMenu.FileIO;
using SpaciousStartMenu.Settings;
using SpaciousStartMenu.Shell;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace SpaciousStartMenu.Views
{
    public partial class SettingsWindow : Window
    {
        private readonly AppSettings _settings;

        public string? ExportFilePath { get; set; } = null;
        public bool Imported { get; private set; } = false;


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
            VersionText.Text = App.Version;

            SettingsToScreen(_settings);
        }

        private void SettingsToScreen(AppSettings stg)
        {
            MinimizeStartup.IsChecked = stg.MinimizeStartup;

            MinimizeStartup2.IsChecked = stg.MinimizeStartup2;
            EscKeyMin.IsChecked = stg.EscKeyMinimize;
            DblClickMin.IsChecked = stg.MarginDoubleClickMinimize;
            CtrlClickDisabledMin.IsChecked = stg.DisabledMinimizeCtrlClick;

            ConfirmClose.IsChecked = stg.ConfirmCloseMenu;

            ShowOpenAndExitMenuItem.IsChecked = stg.ShowOpenAndExitMenuItem;

            SaveScreenSize.IsChecked = stg.SaveScreenSize;
            SaveScreenPos.IsChecked = stg.SaveScreenPosition;

            ShowDirectEditDefine.IsChecked = stg.ShowDirectEditDefineButton;
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
            SaveSettings();
            Close();
        }

        private void SaveSettings()
        {
            _settings.MinimizeStartup = MinimizeStartup.IsChecked == true;

            _settings.MinimizeStartup2 = MinimizeStartup2.IsChecked == true;
            _settings.EscKeyMinimize = EscKeyMin.IsChecked == true;
            _settings.MarginDoubleClickMinimize = DblClickMin.IsChecked == true;
            _settings.DisabledMinimizeCtrlClick = CtrlClickDisabledMin.IsChecked == true;

            _settings.ConfirmCloseMenu = ConfirmClose.IsChecked == true;

            _settings.ShowOpenAndExitMenuItem = ShowOpenAndExitMenuItem.IsChecked == true;

            _settings.SaveScreenSize = SaveScreenSize.IsChecked == true;
            _settings.SaveScreenPosition = SaveScreenPos.IsChecked == true;

            _settings.ShowDirectEditDefineButton = ShowDirectEditDefine.IsChecked == true;
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

        private void MinimizeStartupShortcut_Click(object sender, RoutedEventArgs e)
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

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            var d = DateTime.Now;
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                Title = App.R("R_SaveFileDialogTitle"),
                Filter = "(*.defbkup)|*.defbkup|(*.*)|*.*",
                FileName = $"SpaciousStartMenu-{d.Year:D4}{d.Month:D2}{d.Day:D2}.defbkup",
                DefaultExt = "defbkup",
                CheckPathExists = true
            };

            if (dlg.ShowDialog() == true)
            {
                ExportFilePath = dlg.FileName;
                SaveSettings();
                Close();
            }
        }

        private async void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new Microsoft.Win32.OpenFileDialog
                {
                    Title = App.R("R_OpenFileDialogTitle"),
                    Filter = "(*.defbkup)|*.defbkup|(*.*)|*.*",
                    CheckFileExists = true
                };

                if (dlg.ShowDialog() == true)
                {
                    IsEnabled = false;
                    string launchFilePath = App.GetLaunchDefineFilePath();
                    string settingsFilePath = App.GetAppSettingsFilePath();

                    SettingsImport.Backup(launchFilePath, settingsFilePath);

                    try
                    {
                        await SettingsImport.ImportAsync(dlg.FileName, launchFilePath, settingsFilePath);
                        Imported = true;
                        Close();
                    }
                    catch
                    {
                        SettingsImport.Restore(launchFilePath, settingsFilePath);
                        throw;
                    }

                }
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
            finally
            {
                IsEnabled = true;
            }
        }
    }
}
