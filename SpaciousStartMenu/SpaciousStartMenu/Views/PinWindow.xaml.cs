using SpaciousStartMenu.DataTypes;
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
using System.Windows.Media;

namespace SpaciousStartMenu.Views
{
    public partial class PinWindow : Window
    {
        private readonly Window _parentWindow;
        private readonly Action _postSaveAction;
        private readonly List<MarkColor> _colors = new();
        private bool _isEditing = false;
        private bool _isEdited = false;
        private ObservableCollection<LaunchDefItem>? _defItems;

        public PinWindow(Window parentWindow, Action postSaveAction)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            _postSaveAction = postSaveAction;
            InitializeDefList();
            InitializeColorList();
        }

        private void InitializeDefList()
        {
            var dr = new LaunchDefReader(App.GetLaunchDefFilePath());
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

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isEdited)
            {
                switch (this.Confirm3Buttons(App.R("MsgConfirmDefSave")))
                {
                    case MessageBoxResult.Yes:
                        await SaveDefFileAsync();
                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        e.Cancel = true;
                        return;
                }
            }
            _parentWindow.WindowState = WindowState.Maximized;
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
            _isEdited = true;
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
                _isEdited = true;
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
                _isEdited = true;
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void ShowEditWindow(LaunchDefItem item, bool isNew)
        {
            var win = new EditDetailWindow(new Window[] { _parentWindow, this }, _colors, item);

            _isEditing = true;
            Opacity = 0.5;

            var ret =win.ShowDialog();

            Opacity = 1.0;
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
                _isEdited = true;
            }
            _isEditing = false;
            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newItem = new LaunchDefItem("Black", null, null);
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
                _isEdited = true;
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
                await SaveDefFileAsync();
                btn.IsEnabled = true;
                Close();
            }
            catch (Exception ex)
            {
                btn.IsEnabled = true;
                this.Error(ex.ToString());
            }
        }

        private async Task SaveDefFileAsync()
        {
            if (_defItems is null)
            {
                return;
            }

            string filePath = App.GetLaunchDefFilePath();
            if (File.Exists(filePath))
            {
                File.Copy(filePath, $"{filePath}.bak", overwrite: true);
            }

            var ldw = new LaunchDefWriter(filePath);
            await ldw.WriteToFileAsync(_defItems);

            _isEdited = false;

            _postSaveAction();
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
                - v.Columns[3].ActualWidth  // Buttons
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

    }
}
