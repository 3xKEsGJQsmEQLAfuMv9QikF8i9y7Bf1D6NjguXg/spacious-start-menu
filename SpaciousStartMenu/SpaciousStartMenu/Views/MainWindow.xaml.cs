using SpaciousStartMenu.Settings;
using SpaciousStartMenu.Shell;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

                string filePath = App.GetLaunchDefFilePath();
                CreateDefaultLaunchDefFile(filePath);
                LoadLauncherDef(filePath);
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
                    if (Msg.Confirm(App.GetRes("MsgConfirmCloseMenu")) != MessageBoxResult.Yes)
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
                Msg.Error($"{App.GetRes("MsgErrSaveSettings")}\n{ex}");
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

        private void PinMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_pinWindow is null ||
                !_pinWindow.IsVisible)
            {
                _pinWindow = new PinWindow(this, () => LoadLauncherDef(App.GetLaunchDefFilePath()));
                _pinWindow.Show();
            }
            else
            {
                _pinWindow.Activate();
            }
        }

        private void ScaleItem_Click(object sender, RoutedEventArgs e)
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

        private void MenuSettings_Click(object sender, RoutedEventArgs e)
        {
            var window = new SettingsWindow(_settings);
            window.ShowDialog();
        }

        private void MenuFolderOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string appPath = App.GetAppPath();
                Execute(appPath);
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                Msg.Error(ex.ToString());
            }
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
        }

        private void SetScreen(AppSettings appStg)
        {
            DefaultScaleItem.IsChecked = true;
            foreach (var child in LogicalTreeHelper.GetChildren(ScaleMenu))
            {
                if (child is RadioButton radio &&
                    double.TryParse(radio.Content.ToString(), out double scale) &&
                    scale == appStg.Scale)
                {
                    radio.IsChecked = true;
                    SetContainerScale(scale);
                    break;
                }
            }
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
            double scale = 1.0;
            foreach (var child in LogicalTreeHelper.GetChildren(ScaleMenu))
            {
                if (child is RadioButton radio &&
                    radio.IsChecked == true &&
                    double.TryParse(radio.Content.ToString(), out scale))
                {
                    break;
                }
            }
            _settings.Scale = scale;

            return _settings;
        }

        private void LoadLauncherDef(string filePath)
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
                    columns.Length < 1)
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
                else if (columns.Length == LauncherDefinition.Columns.Count)
                {
                    MakeButton(columns, ref btnContainer, ref _buttonCount, ref _groupCount);
                }
                else
                {
                    throw new Exception(
                        $"{App.GetRes("MsgErrSettingsColumn")}\n{string.Join(LauncherDefinition.Delimiter, columns)}");
                }
            }

            if (_buttonCount == 0 &&
                _groupCount == 0)
            {
                throw new Exception(App.GetRes("MsgErrNoDefinition"));
            }
        }

        private void MakeButton(string[] columns, ref WrapPanel? btnContainer, ref int buttonCount, ref int groupCount)
        {
            if (btnContainer is null)
            {
                MakeGroup(ref btnContainer, ref groupCount);
            }

            Button btn = CreateLaunchButton(
                columns[LauncherDefinition.Columns["Color"]],
                columns[LauncherDefinition.Columns["ButtonTitle"]],
                columns[LauncherDefinition.Columns["Path"]]);
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

        private void CreateDefaultLaunchDefFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return;
            }

            using var sw = new StreamWriter(filePath, append: false, encoding: Encoding.UTF8);
            sw.Write(LauncherDefinition.GetDefaultData());
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

        private Button CreateLaunchButton(string colorName, string text, string execute)
        {
            var btn = new Button();
            var txtContainer = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            
            var txtMark = new TextBlock
            {
                Text = "●",
                Margin = new Thickness(0, 0, 2, 0)
            };

            try
            {
                var bcnv = new BrushConverter();
                txtMark.Foreground = (Brush)bcnv.ConvertFromString(colorName)!;
            }
            catch
            {
                throw new Exception($"{App.GetRes("MsgErrColorName")}[{colorName}]");
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
                if (Execute(execute))
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

        private bool Execute(string cmd)
        {
            try
            {
                ShellExecution.Run(cmd);
                return true;
            }
            catch
            {
                Msg.Error($"{App.GetRes("MsgErrStartup")}\n{cmd}");
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
