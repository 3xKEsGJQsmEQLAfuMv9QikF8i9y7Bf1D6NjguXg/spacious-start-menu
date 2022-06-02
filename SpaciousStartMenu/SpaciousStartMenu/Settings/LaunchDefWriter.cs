using SpaciousStartMenu.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaciousStartMenu.Settings
{
    internal class LaunchDefWriter
    {
        private readonly string _filePath;

        public LaunchDefWriter(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<bool> WriteToFileAsync(ObservableCollection<LaunchDefItem> items)
        {
            try
            {
                using var sw = new StreamWriter(_filePath, append: false, encoding: Encoding.UTF8);

                foreach (var item in items)
                {
                    if (item.IsDelete)
                    {
                        continue;
                    }
                    await sw.WriteLineAsync(item.ToDefString());
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Error(null, ex.ToString());
                return false;
            }
        }

    }
}
