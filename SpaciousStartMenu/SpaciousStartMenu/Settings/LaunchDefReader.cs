using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace SpaciousStartMenu.Settings
{
    internal class LaunchDefReader
    {
        private readonly string _filePath;
        private static readonly LauncherDefinition _btnDef = new();

        public LaunchDefReader(string filePath)
        {
            _filePath = filePath;
        }

        public ObservableCollection<LaunchDefItem> ReadFromFile()
        {
            //LaunchDefItem.ResetId();
            var items = new ObservableCollection<LaunchDefItem>();
            using var reader = new StreamReader(_filePath, Encoding.UTF8);

            while (!reader.EndOfStream)
            {
                // TAB split
                var columns = reader.ReadLine()?.Split(LauncherDefinition.Delimiter);
                if (columns is null ||
                    columns.Length < 1 ||
                    string.IsNullOrWhiteSpace(columns[LauncherDefinition.ColorOrGroupTitleColumnIndex]))
                {
                    // No data
                    continue;
                }

                LaunchDefItem? item;
                if (_btnDef.IsGroupTitle(columns))
                {
                    item = new LaunchDefItem(_btnDef.GetGroupTitle(columns));
                }
                else if (columns.Length == LauncherDefinition.MaxColumns)
                {
                    item = new LaunchDefItem(
                        columns[LauncherDefinition.ColorOrGroupTitleColumnIndex],
                        columns[LauncherDefinition.TitleColumnIndex],
                        columns[LauncherDefinition.PathColumnIndex]);
                }
                else
                {
                    throw new Exception(
                        $"{App.R("MsgErrSettingsColumn")}\n{string.Join(LauncherDefinition.Delimiter, columns)}");
                }

                items.Add(item);
            }

            return items;
        }

    }
}
