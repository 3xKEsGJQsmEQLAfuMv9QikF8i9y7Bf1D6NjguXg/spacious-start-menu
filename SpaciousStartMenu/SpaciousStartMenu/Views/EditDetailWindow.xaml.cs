using SpaciousStartMenu.DataTypes;
using SpaciousStartMenu.Extensions;
using SpaciousStartMenu.Settings;
using SpaciousStartMenu.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpaciousStartMenu.Views
{
    public partial class EditDetailWindow : Window
    {
        private readonly Window[] _parentWindows;
        private readonly List<MarkColor> _colors;
        private readonly LaunchDefItem _item;
        private readonly AppSettings _settings;

        public EditDetailWindow(
            Window[] parentWindows,
            List<MarkColor> colors,
            LaunchDefItem item,
            AppSettings settings)
        {
            InitializeComponent();
            _parentWindows = parentWindows;
            _colors = colors;
            _item = item;
            _settings = settings;
            RestoreWindowSize(_settings);
            ColorList.ItemsSource = _colors;
        }

        private void RestoreWindowSize(AppSettings stg)
        {
            if (stg.SaveScreenPosition)
            {
                WindowStartupLocation = WindowStartupLocation.Manual;
                this.SetWindowPosition(
                    stg.PinEditScreenLeft,
                    stg.PinEditScreenTop);
            }

            if (_settings.SaveScreenSize)
            {
                this.SetWindowSize(
                    stg.PinEditScreenHeight,
                    stg.PinEditScreenWidth);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ItemToScreen(_item);
            UpdateOkButtonEnabled();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveWindowSize(_settings);
        }

        private void SaveWindowSize(AppSettings stg)
        {
            if (stg.SaveScreenPosition)
            {
                stg.PinEditScreenLeft = Left;
                stg.PinEditScreenTop = Top;
            }

            if (stg.SaveScreenSize)
            {
                if (WindowState != WindowState.Maximized)
                {
                    stg.PinEditScreenHeight = Height;
                    stg.PinEditScreenWidth = Width;
                }
            }
        }

        private void ItemToScreen(LaunchDefItem item)
        {
            TitleText.Text = item.Title;

            if (item.ColorName is null)
            {
                HeadlineCheck.IsChecked = true;
            }
            else
            {
                ColorNameLabel.Text = item.ColorName;
                ColorMarkLabel.Foreground = MarkColor.GetBrushFromColorName(item.ColorName);
                PathText.Text = item.Path ?? "";
                WorkDirText.Text = item.WorkDir ?? "";
                ArgsText.Text = item.Args ?? "";

                if (PathText.Text.StartsWith("<CMD:"))
                {
                    SpecialCmd.IsChecked = true;
                }
            }

            var c = _colors.SingleOrDefault(x => x.ColorName == item.ColorName);
            if (c is not null)
            {
                ColorList.SelectedItem = c;
            }
        }

        private void ScreenToItem(LaunchDefItem item)
        {
            item.Title = TitleText.Text;

            if (HeadlineCheck.IsChecked == true)
            {
                item.ColorName = null;
                item.MarkBrush = null;
                item.Path = null;
                item.WorkDir = null;
                item.Args = null;
            }
            else
            {
                item.ColorName = ColorNameLabel.Text;
                item.MarkBrush = ColorMarkLabel.Foreground;
                item.Path = PathText.Text;
                item.WorkDir = SpecialCmd.IsChecked == true ? null : WorkDirText.Text;
                item.Args = SpecialCmd.IsChecked == true ? null : ArgsText.Text;
            }
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPopup.IsOpen = true;
        }

        private void ColorList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ListBox list ||
                list.SelectedItem is not MarkColor item)
            {
                return;
            }

            if (e.OriginalSource is
                System.Windows.Controls.Primitives.RepeatButton or
                System.Windows.Controls.Primitives.Thumb)
            {
                return;
            }

            ColorMarkLabel.Foreground = item.MarkBrush;
            ColorNameLabel.Text = item.ColorName;

            ColorPopup.IsOpen = false;
        }

        private void ColorBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (HeadlineCheck.IsChecked == false)
            {
                ColorPopup.IsOpen = true;
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Escape)
            {
                return;
            }

            if (ColorPopup.IsOpen)
            {
                ColorPopup.IsOpen = false;
                e.Handled = true;
                return;
            }
            else if (SpecialFolderPopup.IsOpen)
            {
                SpecialFolderPopup.IsOpen = false;
                e.Handled = true;
                return;
            }

            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var w in _parentWindows)
            {
                w.WindowState = WindowState.Minimized;
            }
        }

        private void PathText_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
        }

        private void PathText_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOkButtonEnabled();
        }

        private void PathText_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is not string[] dropFiles)
            {
                return;
            }

            string path = dropFiles.FirstOrDefault() ?? "";
            if (path != "")
            {
                TitleText.Text = Path.GetFileName(path);
            }
            PathText.Text = path;
            UpdateOkButtonEnabled();
        }

        private void HeadlineCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (HeadlineCheck.IsChecked == true)
            {
                SpecialCmd.IsChecked = false;
            }
            TitleText.Focus();
        }

        private void HeadlineCheck_Click(object sender, RoutedEventArgs e)
        {
            UpdateOkButtonEnabled();
        }

        private void SeparatorButton_Click(object sender, RoutedEventArgs e)
        {
            TitleText.Text = LauncherDefinition.GroupSeparatorValue;
            TitleText.Focus();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOkButtonEnabled();
        }

        private void UpdateOkButtonEnabled()
        {
            if (HeadlineCheck.IsChecked == true)
            {
                if (string.IsNullOrEmpty(TitleText.Text))
                {
                    OkButton.IsEnabled = false;
                }
                else
                {
                    OkButton.IsEnabled = true;
                }
                return;
            }

            if (string.IsNullOrEmpty(TitleText.Text) ||
                string.IsNullOrWhiteSpace(PathText.Text))
            {
                OkButton.IsEnabled = false;
            }
            else
            {
                OkButton.IsEnabled = true;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ScreenToItem(_item);
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is not TextBox txt)
            {
                return;
            }

            txt.SelectAll();
        }

        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not TextBox t)
            {
                return;
            }

            if (t.IsFocused)
            {
                return;
            }
            e.Handled = true;
            t.Focus();
        }

        private void PathFileRefButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new Microsoft.Win32.OpenFileDialog
                {
                    Title = App.R("R_OpenFileDialogTitle"),
                    Filter = "(*.*)|*.*",
                    CheckFileExists = true
                };

                if (dlg.ShowDialog() == true)
                {
                    PathText.Text = dlg.FileName;
                    TitleText.Text = Path.GetFileName(dlg.FileName);
                    UpdateOkButtonEnabled();
                }
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void SpecialFolderMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == PathContextButton)
            {
                if (SpecialCmd.IsChecked == true)
                {
                    SpecialCmdPopup.PlacementTarget = PathContextButton;
                }
                else
                {
                    SpecialFolderPopup.PlacementTarget = PathContextButton;
                }
            }
            else if (sender == WorkDirContextButton)
            {
                SpecialFolderPopup.PlacementTarget = WorkDirContextButton;
            }
            else
            {
                return;
            }

            if (SpecialCmd.IsChecked == true)
            {
                SpecialCmdPopup.IsOpen = true;
            }
            else
            {
                SpecialFolderPopup.IsOpen = true;
            }
        }

        private void ColorPopup_Opened(object sender, EventArgs e)
        {
            ColorList.Focus();
        }

        private void ColorList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter ||
                ColorList.SelectedItem is not MarkColor item)
            {
                return;
            }

            ColorMarkLabel.Foreground = item.MarkBrush;
            ColorNameLabel.Text = item.ColorName;

            ColorPopup.IsOpen = false;
        }

        private void SpecialFolderPopup_Opened(object sender, EventArgs e)
        {
            SpecialFolderList.Focus();
            ((ListBoxItem)SpecialFolderList.SelectedItem)?.Focus();
        }

        private void FolderList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter ||
                sender is not ListBox list)
            {
                return;
            }
            if (list.SelectedItem is not ListBoxItem item)
            {
                return;
            }

            AddSelectedFolderToTextBox(list, item);

            SpecialFolderPopup.IsOpen = false;
        }

        private void AddSelectedFolderToTextBox(ListBox list, ListBoxItem item)
        {
            string env = list == SpecialFolderList ? "" : "ENV:";
            string content = $"<{env}{item.Content}>";

            if (SpecialFolderPopup.PlacementTarget == PathContextButton)
            {
                PathText.Text = content + PathText.Text;
            }
            else if (SpecialFolderPopup.PlacementTarget == WorkDirContextButton)
            {
                WorkDirText.Text = content + WorkDirText.Text;
            }
        }

        private void FolderList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ListBox list ||
                list.SelectedItem is not ListBoxItem item)
            {
                return;
            }

            if (e.OriginalSource is
                System.Windows.Controls.Primitives.RepeatButton or
                System.Windows.Controls.Primitives.Thumb)
            {
                return;
            }

            AddSelectedFolderToTextBox(list, item);

            SpecialFolderPopup.IsOpen = false;
        }

        private void SpecialCmdPopup_Opened(object sender, EventArgs e)
        {
            SpecialCmdList.Focus();
            ((ListBoxItem)SpecialCmdList.SelectedItem)?.Focus();
        }

        private void CmdList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ListBox list ||
                list.SelectedItem is not ListBoxItem item)
            {
                return;
            }

            if (e.OriginalSource is
                System.Windows.Controls.Primitives.RepeatButton or
                System.Windows.Controls.Primitives.Thumb)
            {
                return;
            }

            SetSelectedCmdToTextBox(item);

            SpecialCmdPopup.IsOpen = false;
        }

        private void CmdList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter ||
                sender is not ListBox list)
            {
                return;
            }
            if (list.SelectedItem is not ListBoxItem item)
            {
                return;
            }

            SetSelectedCmdToTextBox(item);

            SpecialCmdPopup.IsOpen = false;
        }

        private void SetSelectedCmdToTextBox(ListBoxItem item)
        {
            string content = $"<CMD:{item.Content}>";

            PathText.Text = content;
            if (!Enum.TryParse(item.Content.ToString(), out SpecialCommandType sc))
            {
                return;
            }

            TitleText.Text = sc switch
            {
                SpecialCommandType.System_Signout => App.R("R_Menu_Signout"),
                SpecialCommandType.System_Shutdown => App.R("R_Menu_Shutdown"),
                SpecialCommandType.System_Restart => App.R("R_Menu_Restart"),
                SpecialCommandType.App_Minimized => App.R("R_ToolTip_MinimizedButton"),
                SpecialCommandType.App_ScrollToTop => App.R("R_Cmd_ScrollToTop"),
                SpecialCommandType.App_ScrollToBottom => App.R("R_Cmd_ScrollToBottom"),
                SpecialCommandType.Desktop_Show => App.R("R_Cmd_ShowDesktop"),
                SpecialCommandType.Settings_Show => App.R("R_Cmd_ShowSettings"),
                SpecialCommandType.Explorer_CloseAllFolders => App.R("R_Cmd_CloseAllFolders"),
                SpecialCommandType.Info_LaunchButtonCount => App.R("R_Cmd_ButtonCount"),
                SpecialCommandType.Info_GroupTitleCount => App.R("R_Cmd_GroupTitleCount"),
                _ => ""
            };
            TitleText.Focus();
        }

        private void SpecialCmd_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not CheckBox chk)
            {
                return;
            }

            if (chk.IsChecked == true)
            {
                PathContextButton.Focus();
                SpecialCmdPopup.PlacementTarget = PathContextButton;
                SpecialCmdPopup.IsOpen = true;
            }
        }

    }
}
