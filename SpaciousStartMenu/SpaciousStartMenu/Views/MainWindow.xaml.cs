using SpaciousStartMenu.DataTypes;
using SpaciousStartMenu.Settings;
using SpaciousStartMenu.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;

namespace SpaciousStartMenu.Views
{
    public partial class MainWindow : Window
    {
        private readonly LauncherDefinition _btnDef = new();
        private int _buttonCount = 0;
        private int _groupCount = 0;
        private PinWindow? _pinWindow = null;
        private AppSettings _settings = new();
        private readonly Style _groupTitleStyle = (Style)(Application.Current.FindResource("GroupTitleStyle"));
        private static readonly FontFamily _segoeMdl2Font = new("Segoe MDL2 Assets");
        private const string _colorMark = "\uE91F";
        private readonly List<double> _scales = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitleBarMoreButton_Click(object sender, RoutedEventArgs e) =>
            WindowContextMenu.IsOpen = true;

        private void TitleBarMinButton_Click(object sender, RoutedEventArgs e) =>
            WindowState = WindowState.Minimized;

        private void TitleBarCloseButton_Click(object sender, RoutedEventArgs e) =>
            Close();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (App.MinimizeStartup)
                {
                    WindowState = WindowState.Minimized;
                }

                LoadAppSettings();

                GetScales();
                string filePath = App.GetLaunchDefineFilePath();
                CreateDefaultLaunchDefineFile(filePath);
                LoadLauncherDefine(filePath);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (_settings.ConfirmCloseMenu)
                {
                    if (this.Confirm(App.R("MsgConfirmCloseMenu")) != MessageBoxResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                _pinWindow?.Close();
                SaveAppSettings();
            }
            catch (Exception ex)
            {
                this.Error($"{App.R("MsgErrSaveSettings")}\n{ex}");
            }
        }

        private async void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                await Task.Delay(5000);
                if (WindowState == WindowState.Maximized ||
                    WindowState == WindowState.Minimized)
                {
                    return;
                }
                if (Height < (SystemParameters.PrimaryScreenHeight / 3 * 2) ||
                    Width < (SystemParameters.PrimaryScreenWidth / 3 * 2))
                {
                    WindowState = WindowState.Maximized;
                }
            }
            catch
            {
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (_settings.EscKeyMinimize &&
                e.Key == Key.Escape)
            {
                WindowState = WindowState.Minimized;
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_settings.MarginDoubleClickMinimize &&
                e.ChangedButton == MouseButton.Left)
            {
                WindowState = WindowState.Minimized;
            }
        }

        private void Window_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            SuppressContextMenuOpen(e);
        }

        private void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                ChangeScale(e.Delta > 0);
            }
        }

        private void ChangeScale(bool isZoom)
        {
            if (isZoom)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }

        private void PinMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pinWindow is null ||
                    !_pinWindow.IsVisible)
                {
                    _pinWindow = new PinWindow(
                        this,
                        () =>LoadLauncherDefine(App.GetLaunchDefineFilePath()),
                        () => Activate(),
                        _settings);
                    _pinWindow.Owner = this;
                    _pinWindow.Show();
                }
                else
                {
                    _pinWindow.Activate();
                }
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void ScaleItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string? scaleStr = (sender as RadioButton)?.Content?.ToString();
                if (!double.TryParse(scaleStr, out double scale))
                {
                    scale = 1.0;
                    DefaultScaleItem.IsChecked = true;
                }
                SetContainerScale(scale);
                WindowContextMenu.IsOpen = false;
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void MenuSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var window = new SettingsWindow(_settings);
                window.Owner = this;
                window.ShowDialog();
                SetScreenFromSettings(_settings);
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void MenuFolderOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string appPath = App.GetAppPath();
                Execute(appPath, null, null);
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                this.Error(ex.ToString());
            }
        }

        private void MenuFolderOpenAndExit_Click(object sender, RoutedEventArgs e)
        {
            MenuFolderOpen_Click(sender, e);
            Close();
        }

        private void SetContainerScale(double scaleXY)
        {
            MainContainer.LayoutTransform = new ScaleTransform(scaleXY, scaleXY);
        }

        private void ShowException(Exception ex)
        {
            MainContainer.Children.Clear();

            var txt = new TextBox
            {
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5),
                IsReadOnly = true,
                Background = Brushes.Black,
                Foreground = Brushes.Red,
                Text = ex.ToString()
            };

            MainContainer.Children.Add(txt);
        }

        private void LoadAppSettings()
        {
            var asr = new AppSettingsReader();
            _settings = asr.ReadFromFile();
            SetScreen(_settings);
            SetScreenFromSettings(_settings);
        }

        private void SetScreen(AppSettings appStg)
        {
            SetScale(appStg.Scale);
        }

        private void SetScale(double value)
        {
            foreach (var child in LogicalTreeHelper.GetChildren(ScaleMenu))
            {
                if (child is RadioButton radio &&
                    double.TryParse(radio.Content.ToString(), out double scale) &&
                    scale == value)
                {
                    radio.IsChecked = true;
                    SetContainerScale(scale);
                    return;
                }
            }
            DefaultScaleItem.IsChecked = true;
        }

        private void ZoomIn()
        {
            double scale = GetScale();
            if (scale == _scales.Last())
            {
                return;
            }

            for (int i = 0; i < _scales.Count - 1; i++)
            {
                if (_scales[i] == scale)
                {
                    SetScale(_scales[i + 1]);
                    break;
                }
            }
        }

        private void ZoomOut()
        {
            double scale = GetScale();
            if (scale == _scales.First())
            {
                return;
            }

            for (int i = _scales.Count - 1; 1 <= i; i--)
            {
                if (_scales[i] == scale)
                {
                    SetScale(_scales[i - 1]);
                    break;
                }
            }
        }

        /// <summary>
        /// Reflects the contents of the settings screen
        /// </summary>
        /// <param name="appStg"></param>
        private void SetScreenFromSettings(AppSettings appStg)
        {
            MenuItemFolderOpenAndExit.Visibility =
                appStg.ShowOpenAndExitMenuItem
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void SaveAppSettings()
        {
            if (App.Abend)
            {
                return;
            }

            var appStg = GetScreen();
            var asw = new AppSettingsWriter();

            asw.WriteToFile(appStg);
        }

        private AppSettings GetScreen()
        {
            _settings.Scale = GetScale();

            return _settings;
        }

        private void GetScales()
        {
            _scales.Clear();
            foreach (var child in LogicalTreeHelper.GetChildren(ScaleMenu))
            {
                if (child is RadioButton radio &&
                    double.TryParse(radio.Content.ToString(), out double scale))
                {
                    _scales.Add(scale);
                }
            }
        }

        private double GetScale()
        {
            foreach (var child in LogicalTreeHelper.GetChildren(ScaleMenu))
            {
                if (child is RadioButton radio &&
                    radio.IsChecked == true &&
                    double.TryParse(radio.Content.ToString(), out double scale))
                {
                    return scale;
                }
            }
            return 1.0;
        }

        private void LoadLauncherDefine(string filePath)
        {
            MainContainer.Children.Clear();
            using var reader = new StreamReader(filePath, Encoding.UTF8);
            WrapPanel? btnContainer = null;

            _buttonCount = 0;
            _groupCount = 0;

            while (!reader.EndOfStream)
            {
                // TAB split
                var columns = reader.ReadLine()?.Split(LauncherDefinition.Delimiter);
                if (columns is null ||
                    columns.Length < 1 ||
                    string.IsNullOrWhiteSpace(columns[0]))
                {
                    // No data
                    continue;
                }

                /*
                MainContainer           ..... StackPanel
                    grpContainer        ..... StackPanel
                        Title           ..... TextBlock
                        btnContainer    ..... WrapPanel
                            Button
                            Button
                            :
                    grpContainer        ..... StackPanel
                        Title           ..... TextBlock
                        btnContainer    ..... WrapPanel
                            Button
                            Button
                            :
                */

                if (_btnDef.IsGroupTitle(columns))
                {
                    MakeGroup(ref btnContainer, ref _groupCount, _btnDef.GetGroupTitle(columns));
                }
                else if (LauncherDefinition.RequiredColumns <= columns.Length)
                {
                    MakeButton(columns, ref btnContainer, ref _buttonCount, ref _groupCount);
                }
                else
                {
                    throw new Exception(
                        $"{App.R("MsgErrSettingsColumn")}\n{string.Join(LauncherDefinition.Delimiter, columns)}");
                }
            }

        }

        private void MakeButton(string[] columns, ref WrapPanel? btnContainer, ref int buttonCount, ref int groupCount)
        {
            if (btnContainer is null)
            {
                MakeGroup(ref btnContainer, ref groupCount);
            }

            Button btn = CreateLaunchButton(
                columns[LauncherDefinition.ColorOrGroupTitleColumnIndex],
                columns[LauncherDefinition.TitleColumnIndex],
                columns[LauncherDefinition.PathColumnIndex],
                LauncherDefinition.WorkDirColumnIndex <= columns.Length - 1 ? columns[LauncherDefinition.WorkDirColumnIndex] : null,
                LauncherDefinition.ArgsColumnIndex <= columns.Length - 1 ? columns[LauncherDefinition.ArgsColumnIndex] : null);
            
            btnContainer?.Children.Add(btn);

            buttonCount++;
        }

        private void MakeGroup(ref WrapPanel? btnContainer, ref int groupCount, string groupTitle = "")
        {
            var grpContainer = new StackPanel();
            MainContainer.Children.Add(grpContainer);

            if (string.IsNullOrEmpty(groupTitle) == false)
            {
                grpContainer.Children.Add(CreateGroupTitle(groupTitle));
            }

            btnContainer = new WrapPanel();
            grpContainer.Children.Add(btnContainer);
            groupCount++;
        }

        private void CreateDefaultLaunchDefineFile(string filePath)
        {
            if (!IsEmptyFile(filePath))
            {
                return;
            }

            using var sw = new StreamWriter(filePath, append: false, encoding: Encoding.UTF8);
            sw.Write(LauncherDefinition.GetDefaultData());
        }

        private bool IsEmptyFile(string filePath)
        {
            const int bomAndCrLfSize = 5;

            if (File.Exists(filePath))
            {
                var f = new FileInfo(filePath);
                return f.Length <= bomAndCrLfSize;
            }

            return true;
        }

        private TextBlock CreateGroupTitle(string title)
        {

            var txt = new TextBlock
            {
                Style = _groupTitleStyle,
                Text = title
            };

            return txt;
        }

        private Button CreateLaunchButton(
            string colorName,
            string text,
            string execute,
            string? workDir,
            string? args)
        {
            var btn = new Button();
            var txtContainer = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            
            var txtMark = new TextBlock
            {
                FontFamily = _segoeMdl2Font,
                Text = _colorMark,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 4, 0)
            };

            try
            {
                txtMark.Foreground = MarkColor.GetBrushFromColorName(colorName);
            }
            catch
            {
                throw new Exception($"{App.R("MsgErrColorName")}[{colorName}]");
            }

            txtContainer.Children.Add(txtMark);

            var txt = new TextBlock
            {
                Text = text
            };
            txtContainer.Children.Add(txt);

            btn.Content = txtContainer;
            btn.Click += (_, _) =>
            {
                if (Execute(execute, workDir, args))
                {
                    MinimizedWindow();
                }
            };

            return btn;
        }

        private void MinimizedWindow()
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) ||
                Keyboard.IsKeyDown(Key.RightCtrl)) &&
                _settings.DisabledMinimizeCtrlClick)
            {
                return;
            }
            WindowState = WindowState.Minimized;
        }

        private bool Execute(string cmd, string? workDir, string? args)
        {
            try
            {
                ShellExecution.Run(cmd, workDir, args);
                return true;
            }
            catch
            {
                this.Error($"{App.R("MsgErrStartup")}\n{cmd}");
                return false;
            }
        }

        private void SuppressContextMenuOpen(ContextMenuEventArgs e)
        {
            if (e.Source != TitleBarMoreButton &&
                e.Source is Button)
            {
                e.Handled = true;
                return;
            }

            if (e.Source is TextBlock txt &&
                txt.Style != _groupTitleStyle)
            {
                // Text in the launch button
                e.Handled = true;
                return;
            }
        }

    }
}
