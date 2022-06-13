using System.IO;
using System.Text.Json;

namespace SpaciousStartMenu.Settings
{
    internal class AppSettingsReader
    {
        public bool ExistsFile()
        {
            return File.Exists(App.GetAppSettingsFilePath());
        }

        public AppSettings ReadFromFile()
        {
            if (!ExistsFile())
            {
                return new AppSettings();
            }

            string jsonStr = File.ReadAllText(App.GetAppSettingsFilePath());
            if (string.IsNullOrWhiteSpace(jsonStr))
            {
                return new AppSettings();
            }

            var stg = JsonSerializer.Deserialize<AppSettings>(jsonStr);

            return stg ?? new AppSettings();
        }
    }
}
