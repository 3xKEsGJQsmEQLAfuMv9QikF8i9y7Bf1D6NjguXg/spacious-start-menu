using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SpaciousStartMenu.Views
{
    public partial class PinWindow : Window
    {
        private readonly Window _parentWindow;
        private readonly Action _postSaveAction;
        private const string _descriptionHeader = @"Group headings begin with '//'.
TAB delimitation between items.

<< Definition format >>

//GroupTitle
ColorName   ButtonTitle Path
ColorName   ButtonTitle Path
:
//GroupTitle
ColorName   ButtonTitle Path
:

<< Color name list >>
";

        public PinWindow(Window parentWindow, Action postSaveAction)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            _postSaveAction = postSaveAction;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string filePath = App.GetLaunchDefFilePath();
            using var reader = new StreamReader(filePath, Encoding.UTF8);
            DefText.Text = await reader.ReadToEndAsync();
            SetDescription();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _parentWindow.WindowState = WindowState.Maximized;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn)
            {
                return;
            }

            try
            {
                btn.IsEnabled = false;
                string filePath = App.GetLaunchDefFilePath();
                if (File.Exists(filePath))
                {
                    File.Copy(filePath, $"{filePath}.bak", overwrite: true);
                }
                using var sw = new StreamWriter(filePath, append: false, encoding: Encoding.UTF8);
                sw.Write(DefText.Text);
                sw.Dispose();
                _postSaveAction();
                Close();
            }
            catch (Exception ex)
            {
                btn.IsEnabled = true;
                Msg.Error(ex.ToString());
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DispColorList_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not CheckBox chk)
            {
                return;
            }

            if (chk.IsChecked == true)
            {
                DefText.Visibility = Visibility.Collapsed;
                ColorList.Visibility = Visibility.Visible;
            }
            else
            {
                DefText.Visibility = Visibility.Visible;
                ColorList.Visibility = Visibility.Collapsed;
            }
        }

        private void SetDescription()
        {
            ColorList.Document.Blocks.Add(new Paragraph(new Run(_descriptionHeader)));
            var bc = new BrushConverter();
            var docList = new System.Windows.Documents.List();

            var bList = typeof(Brushes).GetProperties()
                .Where(x => x.Name != "Transparent")
                .OrderBy(x => x.Name);
            foreach (var b in bList)
            {
                var li = new ListItem();
                var p = new Paragraph();
                var r = new Run("● ")
                {
                    Foreground = (Brush)bc.ConvertFromString(b.Name)!
                };
                p.Inlines.Add(r);
                p.Inlines.Add(new Run(b.Name));

                li.Blocks.Add(p);
                docList.ListItems.Add(li);
            }

            ColorList.Document.Blocks.Add(docList);
            ColorList.Document.Blocks.Add(new Paragraph(new Run("")));
        }

    }
}
