using SpaciousStartMenu.DataTypes;
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
        private static double _previousWidth = 0.0;
        private static double _previousHeight = 0.0;

        public EditDetailWindow(Window[] parentWindows, List<MarkColor> colors, LaunchDefItem item)
        {
            _parentWindows = parentWindows;
            _colors = colors;
            _item = item;

            InitializeComponent();
            ColorList.ItemsSource = _colors;
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            RestoreTemporaryWindowSize();
        }

        private void RestoreTemporaryWindowSize()
        {
            if (_previousHeight != 0.0 &&
                _previousWidth != 0.0)
            {
                Height = _previousHeight;
                Width = _previousWidth;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ItemToScreen(_item);
            UpdateOkButtonEnabled();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveTemporaryWindowSize();
        }

        private void SaveTemporaryWindowSize()
        {
            _previousWidth = Width;
            _previousHeight = Height;
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
                PathText.Text = item.Path;
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
            }
            else
            {
                item.ColorName = ColorNameLabel.Text;
                item.MarkBrush = ColorMarkLabel.Foreground;
                item.Path = PathText.Text;
            }
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPopup.IsOpen = true;
        }

        private void ColorList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if ((sender as ListBox)?.SelectedItem is not MarkColor item)
            {
                return;
            }

            ColorMarkLabel.Foreground = item.MarkBrush;
            ColorNameLabel.Text = item.ColorName;

            ColorPopup.IsOpen = false;

        }

        private void ColorBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

    }
}
