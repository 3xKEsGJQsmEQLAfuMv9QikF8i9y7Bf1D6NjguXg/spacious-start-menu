using SpaciousStartMenu.Shell;
using SpaciousStartMenu.Views;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace SpaciousStartMenu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string AppSettingsFileName = "settings.json";
        public const string LaunchDefineFileName = "menuItems.def";

        private const string _defaultLanguage = "en-US";

        // Multiple launch prohibition only for programs in the same location.
        private static readonly Mutex _mutex = new(false, $"{GetAppPath().Replace('\\', '_')}_SpaciousStartMenu");
        private static bool _isMutexOwner = false;

        public static bool Abend { get; private set; } = false;
        public static bool MinimizeStartup { get; private set; } = false;

        public App()
        {
            InitializeComponent();
            SetLanguageResource();
        }

        private void SetLanguageResource()
        {
            var rd = new ResourceDictionary();
            string lang = CultureInfo.CurrentUICulture.Name switch
            {
                "ja-JP" => CultureInfo.CurrentUICulture.Name,
                "zh-CN" => CultureInfo.CurrentUICulture.Name,
                "zh-TW" => CultureInfo.CurrentUICulture.Name,
                "ko-KR" => CultureInfo.CurrentUICulture.Name,
                "es-ES" => CultureInfo.CurrentUICulture.Name,
                _ => _defaultLanguage,
            };
            rd.Source = new Uri($"/SpaciousStartMenu;component/Resources/{lang}.xaml", UriKind.Relative);
            Resources.MergedDictionaries[0] = rd;
        }

        /// <summary>
        /// Get resource string
        /// </summary>
        /// <param name="key">resource key</param>
        /// <returns>resource string</returns>
        public static string R(string key) =>
            Current?.Resources[key]?.ToString() ?? "";

        public static string GetAppPath()
        {
            string? appPath = AppContext.BaseDirectory;
            if (appPath is null)
            {
                throw new DirectoryNotFoundException(App.R("MsgErrGetExePath"));
            }

            return appPath;
        }

        public static string GetAppSettingsFilePath() =>
            Path.Combine(GetAppPath(), AppSettingsFileName);

        public static string GetLaunchDefineFilePath() =>
            Path.Combine(GetAppPath(), LaunchDefineFileName);

        protected override void OnStartup(StartupEventArgs e)
        {
            if (!(_isMutexOwner = _mutex.WaitOne(0, false)))
            {
                ForegroundWindow();
                Shutdown();
                return;
            }

            base.OnStartup(e);
        }

        private void ForegroundWindow()
        {
            var current = Process.GetCurrentProcess();
            if (current is null)
            {
                return;
            }
            var processes = Process.GetProcessesByName(current.ProcessName);
            foreach (var p in processes)
            {
                if (p is null ||
                    p.Id == current.Id ||
                    p.MainModule is null)
                {
                    continue;
                }
                if (p.MainModule.FileName == current.MainModule?.FileName)
                {
                    Win32.Window.ActivateWindow(p.MainWindowHandle);
                    break;
                }
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            if (_isMutexOwner)
            {
                _mutex.ReleaseMutex();
            }
            _mutex.Close();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (Environment.OSVersion.Version.Major < 10)
            {
                MsgBox.Error(null, App.R("MsgErrUnsupportedOS"));
                Abend = true;
                Shutdown();
                return;
            }

            if (!ValidateInstallPath())
            {
                MsgBox.Error(null, App.R("MsgErrAdminInstallPath"));

                if (MsgBox.Confirm(null, App.R("MsgConfirmCreateRecommendInstallFolder")) == MessageBoxResult.Yes)
                {
                    string path = GetReccomendInstallPath();
                    Directory.CreateDirectory(path);
                    ShellExecution.Run(path, null, null);
                }
                Abend = true;
                Shutdown();
                return;
            }

            SetJumpList();

            string? arg1 = e.Args.FirstOrDefault();
            if (arg1 == "/min")
            {
                MinimizeStartup = true;
            }
        }

        private void SetJumpList()
        {
            var jumpList = new System.Windows.Shell.JumpList();

            jumpList.JumpItems.Add(
                new System.Windows.Shell.JumpTask()
                {
                    Title = R("R_TaskManager"),
                    ApplicationPath = "Taskmgr.exe",
                    IconResourceIndex = -1,
                });

            jumpList.JumpItems.Add(
                new System.Windows.Shell.JumpTask()
                {
                    Title = R("R_Explorer"),
                    ApplicationPath = "Explorer.exe",
                    IconResourceIndex = -1,
                });

            jumpList.JumpItems.Add(
                new System.Windows.Shell.JumpTask()
                {
                    Title = R("R_Run"),
                    ApplicationPath = "Explorer.exe",
                    Arguments = "Shell:::{2559A1F3-21D7-11D4-BDAF-00C04F60B9F0}",
                    IconResourceIndex = -1,
                });

            jumpList.Apply();
        }

        private static bool ValidateInstallPath()
        {
            if (AppContext.BaseDirectory.StartsWith(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), StringComparison.OrdinalIgnoreCase) ||
                AppContext.BaseDirectory.StartsWith(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }

        private static string GetReccomendInstallPath() => Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                @"Tools\SpaciousStartMenu");

    }

}
