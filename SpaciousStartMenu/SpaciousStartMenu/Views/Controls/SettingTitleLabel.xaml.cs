using System.Windows;
using System.Windows.Controls;

namespace SpaciousStartMenu.Views.Controls
{
    public partial class SettingTitleLabel : UserControl
    {
        public SettingTitleLabel()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text), typeof(string), typeof(SettingTitleLabel), new PropertyMetadata(string.Empty));


    }
}
