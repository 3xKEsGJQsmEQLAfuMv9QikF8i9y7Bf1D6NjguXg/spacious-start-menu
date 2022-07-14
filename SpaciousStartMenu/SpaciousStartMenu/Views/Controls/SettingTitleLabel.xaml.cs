using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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

        public void Hilight()
        {
            var board = (Storyboard)FindResource("HilightAnimation");
            if (board is not null)
            {
                board.Begin();
            }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text), typeof(string), typeof(SettingTitleLabel), new PropertyMetadata(string.Empty));


    }
}
