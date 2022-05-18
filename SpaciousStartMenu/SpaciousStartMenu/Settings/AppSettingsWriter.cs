using System.IO;
using System.Text.Json;
using JE = System.Text.Encodings.Web;
using UN = System.Text.Unicode;

namespace SpaciousStartMenu.Settings
{
    internal class AppSettingsWriter
    {
        public void WriteToFile(AppSettings stg)
        {
            var opt = new JsonSerializerOptions
            {
                Encoder = JE.JavaScriptEncoder.Create(UN.UnicodeRanges.All),
                WriteIndented = true,
            };

            string jsonStr = JsonSerializer.Serialize(stg, opt);
            File.WriteAllText(App.GetAppSettingsFilePath(), jsonStr);
        }
    }
}
