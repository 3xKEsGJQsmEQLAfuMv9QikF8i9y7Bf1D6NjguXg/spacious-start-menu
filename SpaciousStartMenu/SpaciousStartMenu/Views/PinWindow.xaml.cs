using SpaciousStartMenu.DataTypes;
using SpaciousStartMenu.Extensions;
using SpaciousStartMenu.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SpaciousStartMenu.Views
{
    public partial class PinWindow : Window
    {
        private readonly MainWindow _mainWindow;
        private readonly Action _postSaveAction;
        private readonly Action _postCloseAction;
        private readonly AppSettings _settings;
        private readonly List<MarkColor> _colors = new();
        private bool _isEditing = false;
        private bool _hasError = false;
        private ObservableCollection<LaunchDefItem>? _defItems;
        private readonly PinVm _pinVm = new();

        public PinWindow(
            MainWindow mainWindow,
            Action postSaveAction,
            Action postCloseAction,
            AppSettings settings)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _postSaveAction = postSaveAction;
            _postCloseAction = postCloseAction;
            _settings = settings;
            RestoreWindowSize(_settings);
            DataContext = _pinVm;
            _pinVm.IsEdited = false;

            DirectEditButton.Visibility = _settings.ShowDirectEditDefineButton
                ? Visibility.Visible
                : Visibility.Collapsed;

            InitializeDefList();
            InitializeColorList();
        }

        private void InitializeDefList()
        {
            var dr = new LaunchDefReader(App.GetLaunchDefineFilePath());
            _defItems = dr.ReadFromFile();

            DefList.Items.Clear();
            DefList.ItemsSource = _defItems;
        }

        private void InitializeColorList()
        {
            var bList = typeof(Brushes).GetProperties()
                .Where(x => x.Name != "Transparent");

            foreach (var b in bList)
            {
                _colors.Add(new MarkColor(b.Name));
            }

            var cv = CollectionViewSource.GetDefaultView(_colors);
            cv.SortDescriptions.Clear();
            cv.SortDescriptions.Add(new SortDescription("Order", ListSortDirection.Ascending));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SaveIcon.Foreground = new SolidColorBrush(SystemParameters.WindowGlassColor);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Alt)
            {
                if (e.SystemKey == Key.Up &&
                    UpButton.IsEnabled)
                {
                    UpButton_Click(sender, e);
                }
                else if (e.SystemKey == Key.Down &&
                    DownButton.IsEnabled)
                {
                    DownButton_Click(sender, e);
                }
            }
        }

        private void RestoreWindowSize(AppSettings stg)
        {
            if (stg.SaveScreenPosition)
            {
                WindowStartupLocation = WindowStartupLocation.Manual;
                this.SetWindowPosition(
                    stg.PinListScreenLeft,
                    stg.PinListScreenTop);
            }

            if (_settings.SaveScreenSize)
            {
                this.SetWindowSize(
                    stg.PinListScreenHeight,
                    stg.PinListScreenWidth,
                    stg.PinListScreenMaximum);
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (_hasError)
                {
                    if (HasErrorClosingProc(e))
                    {
                        _postSaveAction();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (_pinVm.IsEdited)
                {
                    if (!await IsEditedClosingProcAsync(e))
                    {
                        return;
                    }
                }

                _mainWindow.WindowState = WindowState.Maximized;
                SaveWindowSize(_settings);
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private bool HasErrorClosingProc(CancelEventArgs e)
        {
            if (this.Confirm(App.R("MsgConfirmUndoDef")) == MessageBoxResult.Yes)
            {
                string filePath = App.GetLaunchDefineFilePath();
                File.Copy(FileIO.BackupFile.GetFilePath(filePath), filePath, overwrite: true);
                return true;
            }
            else
            {
                e.Cancel = true;
                return false;
            }
        }

        private async Task<bool> IsEditedClosingProcAsync(CancelEventArgs e)
        {
            switch (this.Confirm3Buttons(App.R("MsgConfirmDefSave")))
            {
                case MessageBoxResult.Yes:
                    if (!await SaveDefFileAsync())
                    {
                        e.Cancel = true;
                        return false;
                    }
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    e.Cancel = true;
                    return false;
            }

            return true;
        }

        private void SaveWindowSize(AppSettings stg)
        {
            if (stg.SaveScreenPosition)
            {
                stg.PinListScreenLeft = Left;
                stg.PinListScreenTop = Top;
            }

            if (stg.SaveScreenSize)
            {
                stg.PinListScreenMaximum = WindowState == WindowState.Maximized;
                if (!stg.PinListScreenMaximum)
                {
                    stg.PinListScreenHeight = Height;
                    stg.PinListScreenWidth = Width;
                }
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                return;
            }
            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void EditListButton_Click(object sender, RoutedEventArgs e)
        {
            if (DefList.SelectedItem is not LaunchDefItem item)
            {
                return;
            }
            ShowEditWindow(item, false);
        }

        private void DeleteListButton_Click(object sender, RoutedEventArgs e)
        {
            if (DefList.SelectedItem is not LaunchDefItem item)
            {
                return;
            }

            item.IsDelete = !item.IsDelete;
            _pinVm.IsEdited = true;
        }

        private async void DirectEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = App.GetLaunchDefineFilePath();
                if (System.IO.File.Exists(filePath))
                {
                    using var sr = new StreamReader(filePath, Encoding.UTF8);
                    DefText.Text = await sr.ReadToEndAsync();
                    _pinVm.IsEdited = false;
                }

                DefList.Visibility = Visibility.Collapsed;
                DefText.Visibility = Visibility.Visible;

                DirectEditButton.Visibility = Visibility.Collapsed;

                UpButton.IsEnabled = false;
                DownButton.IsEnabled = false;
                AddButton.IsEnabled = false;
                DuplicateButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (DefList.SelectedIndex < 1)
            {
                return;
            }

            try
            {
                int curIdx = DefList.SelectedIndex;
                int newIdx = curIdx - 1;
                var selectedItem = DefList.SelectedItem as LaunchDefItem;
                _defItems?.Remove(selectedItem!);
                _defItems?.Insert(newIdx, selectedItem!);
                DefList.SelectedIndex = newIdx;
                _pinVm.IsEdited = true;
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (DefList.SelectedIndex == -1 ||
                DefList.SelectedIndex == _defItems?.Count - 1)
            {
                return;
            }

            try
            {
                int curIdx = DefList.SelectedIndex;
                int newIdx = curIdx + 1;
                var selectedItem = DefList.SelectedItem as LaunchDefItem;
                _defItems?.Remove(selectedItem!);
                _defItems?.Insert(newIdx, selectedItem!);
                DefList.SelectedIndex = newIdx;
                _pinVm.IsEdited = true;
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void ShowEditWindow(LaunchDefItem item, bool isNew)
        {
            var win = new EditDetailWindow(
                new Window[] { _mainWindow, this },
                _colors,
                item,
                _settings);

            _isEditing = true;
            Opacity = 0.5;
            _mainWindow.SetDisabledStyle();

            win.Owner = this;
            bool? ret;
            try
            {
                ret = win.ShowDialog();
            }
            finally
            {
                Opacity = 1.0;
                _mainWindow.SetDisabledStyle(false);
            }

            if (isNew &&
                ret == true)
            {
                _defItems?.Insert(DefList.SelectedIndex + 1, item);
                DefList.SelectedIndex++;
                if (DefList.SelectedIndex == DefList.Items.Count - 1)
                {
                    DefList.ScrollIntoView(DefList.Items[^1]);
                }
            }
            if (ret == true)
            {
                _pinVm.IsEdited = true;
            }
            _isEditing = false;
            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
                _mainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newItem = new LaunchDefItem("Black", null, null, null, null);
                ShowEditWindow(newItem, true);
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void DuplicateButton_Click(object sender, RoutedEventArgs e)
        {
            if (DefList.SelectedIndex == -1)
            {
                return;
            }
            if (DefList.SelectedItem is not LaunchDefItem selectedItem)
            {
                return;
            }

            try
            {
                int curIdx = DefList.SelectedIndex;
                int newIdx = curIdx + 1;
                _defItems?.Insert(newIdx, selectedItem.Copy());
                DefList.SelectedIndex = newIdx;
                if (DefList.SelectedIndex == DefList.Items.Count - 1)
                {
                    DefList.ScrollIntoView(DefList.Items[^1]);
                }
                _pinVm.IsEdited = true;
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn)
            {
                return;
            }

            try
            {
                btn.IsEnabled = false;
                bool saved = await SaveDefFileAsync();
                btn.IsEnabled = true;
                if (saved)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                btn.IsEnabled = true;
                this.Error(ex.ToString());
            }
        }

        private async Task<bool> SaveDefFileAsync()
        {
            if (_defItems is null)
            {
                return false;
            }

            string filePath = App.GetLaunchDefineFilePath();
            if (File.Exists(filePath) && !_hasError)
            {
                File.Copy(filePath, FileIO.BackupFile.GetFilePath(filePath), overwrite: true);
            }

            if (DefList.Visibility == Visibility.Visible)
            {
                // List
                var ldw = new LaunchDefWriter(filePath);
                await ldw.WriteToFileAsync(_defItems);
            }
            else
            {
                // Text
                using var sw = new StreamWriter(filePath, append: false, encoding: Encoding.UTF8);
                await sw.WriteLineAsync(DefText.Text);
            }

            try
            {
                _postSaveAction();
                _pinVm.IsEdited = false;
                _hasError = false;
            }
            catch (Exception ex)
            {
                _hasError = true;
                this.Error(ex.ToString());
                return false;
            }

            return true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DefList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is not ListView lv ||
                lv.View is not GridView v)
            {
                return;
            }

            const double MarginW = 18.0;
            const double MinW = 100.0;

            var w = lv.ActualWidth
                - v.Columns[0].ActualWidth  // Color
                - v.Columns[1].ActualWidth  // Title
                - v.Columns[3].ActualWidth  // Work Dir
                - v.Columns[4].ActualWidth  // Args
                - v.Columns[5].ActualWidth  // Buttons
                - MarginW;
            if (w < MinW)
            {
                w = MinW;
            }
            v.Columns[2].Width = w;
        }

        private void DefListItem_PreviewGotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (sender is ListViewItem item)
            {
                item.IsSelected = true;
            }
        }

        private void DefListItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is ListViewItem listItem &&
                listItem is not null)
            {
                var item = (LaunchDefItem)listItem.DataContext;
                if (!item.IsDelete)
                {
                    ShowEditWindow(item, false);
                }
            }

        }

        private void DefListItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete)
            {
                return;
            }
            if (DefList.SelectedIndex == -1)
            {
                return;
            }
            if (DefList.SelectedItem is not LaunchDefItem item)
            {
                return;
            }

            item.IsDelete = !item.IsDelete;
            _pinVm.IsEdited = true;
        }

        private void DefText_TextChanged(object sender, TextChangedEventArgs e)
        {
            _pinVm.IsEdited = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _postCloseAction();
        }
    }

    class PinVm : NotifyPropertyChanged
    {
        private bool _isEdited;
        public bool IsEdited
        {
            get => _isEdited;
            set => SetProperty(ref _isEdited, value);
        }
    }
}
