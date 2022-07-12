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
            int groupCount = 0;
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
                    string title = _btnDef.GetGroupTitle(columns);
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        continue;
                    }
                    groupCount++;
                    item = new LaunchDefItem(title);
                    item.GroupNo = groupCount;
                }
                else if (LauncherDefinition.RequiredColumns <= columns.Length)
                {
                    item = new LaunchDefItem(
                        columns[LauncherDefinition.ColorOrGroupTitleColumnIndex],
                        columns[LauncherDefinition.TitleColumnIndex],
                        columns[LauncherDefinition.PathColumnIndex],
                        LauncherDefinition.WorkDirColumnIndex <= columns.Length - 1 ? columns[LauncherDefinition.WorkDirColumnIndex] : null,
                        LauncherDefinition.ArgsColumnIndex <= columns.Length - 1 ? columns[LauncherDefinition.ArgsColumnIndex] : null);
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
