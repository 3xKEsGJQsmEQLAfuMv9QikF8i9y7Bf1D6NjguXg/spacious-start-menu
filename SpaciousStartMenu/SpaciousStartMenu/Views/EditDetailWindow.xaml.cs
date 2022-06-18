using SpaciousStartMenu.DataTypes;
using SpaciousStartMenu.Extensions;
using SpaciousStartMenu.Settings;
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
                item.WorkDir = WorkDirText.Text;
                item.Args = ArgsText.Text;
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

        private void PathText_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is not string[] dropFiles)
            {
                return;
            }

            string path = dropFiles.FirstOrDefault() ?? "";
            if (path != "" &&
                string.IsNullOrEmpty(TitleText.Text))
            {
                TitleText.Text = Path.GetFileName(path);
            }
            PathText.Text = path;
            UpdateOkButtonEnabled();
        }

        private void HeadlineCheck_Checked(object sender, RoutedEventArgs e)
        {
            TitleText.Focus();
        }

        private void HeadlineCheck_Click(object sender, RoutedEventArgs e)
        {
            UpdateOkButtonEnabled();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOkButtonEnabled();
        }

        private void UpdateOkButtonEnabled()
        {
            if (string.IsNullOrWhiteSpace(TitleText.Text) ||
                (HeadlineCheck.IsChecked == false &&
                string.IsNullOrWhiteSpace(PathText.Text)))
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

        private void SpecialFolderMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == PathContextButton)
            {
                SpecialFolderPopup.PlacementTarget = PathContextButton;
            }
            else if (sender == WorkDirContextButton)
            {
                SpecialFolderPopup.PlacementTarget = WorkDirContextButton;
            }
            else
            {
                return;
            }

            SpecialFolderPopup.IsOpen = true;
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

            AddSelectedValueToTextBox(list, item);

            SpecialFolderPopup.IsOpen = false;
        }

        private void AddSelectedValueToTextBox(ListBox list, ListBoxItem item)
        {
            string env = list == SpecialFolderList ? "" : "ENV:";
            string content = $"<{env}{item.Content}>";

            if (SpecialFolderPopup.PlacementTarget == PathContextButton)
            {
                PathText.Text += content;
            }
            else if (SpecialFolderPopup.PlacementTarget == WorkDirContextButton)
            {
                WorkDirText.Text += content;
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

            AddSelectedValueToTextBox(list, item);

            SpecialFolderPopup.IsOpen = false;
        }
    }
}
