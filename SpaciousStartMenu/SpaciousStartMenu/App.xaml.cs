using SpaciousStartMenu.Shell;
using SpaciousStartMenu.Views;
using System;
using System.Globalization;
using System.IO;
using System.Windows;

namespace SpaciousStartMenu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string AppSettingsFileName = "settings.json";
        public const string LaunchDefFileName = "menuItems.def";
        private const string DefaultLanguage = "en-US";
        public static bool Abend { get; private set; } = false;

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
                _ => DefaultLanguage,
            };
            rd.Source = new Uri($"/SpaciousStartMenu;component/Resources/{lang}.xaml", UriKind.Relative);
            Resources.MergedDictionaries[0] = rd;
        }

        public static string GetRes(string key) =>
            Current?.Resources[key]?.ToString() ?? "";

        public static string GetAppPath()
        {
            string? appPath = AppContext.BaseDirectory;
            if (appPath is null)
            {
                throw new DirectoryNotFoundException(App.GetRes("MsgErrGetExePath"));
            }

            return appPath;
        }

        public static string GetAppSettingsFilePath() =>
            Path.Combine(GetAppPath(), AppSettingsFileName);

        public static string GetLaunchDefFilePath() =>
            Path.Combine(GetAppPath(), LaunchDefFileName);

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (Environment.OSVersion.Version.Major < 10)
            {
                MessageBox.Show(App.GetRes("MsgErrUnsupportedOS"));
                Abend = true;
                Shutdown();
            }

            if (ValidateInstallPath())
            {
                // OK
                return;
            }

            // NG
            Msg.Error(App.GetRes("MsgErrAdminInstallPath"));

            if (Msg.Confirm(App.GetRes("MsgConfirmCreateRecommendInstallFolder")) == MessageBoxResult.Yes)
            {
                string path = GetReccomendInstallPath();
                Directory.CreateDirectory(path);
                ShellExecution.Run(path);
            }
            Abend = true;
            Shutdown();
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
