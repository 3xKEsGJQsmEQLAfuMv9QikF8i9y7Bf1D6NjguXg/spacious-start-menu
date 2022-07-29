using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SpaciousStartMenu.Views.Controls
{
    public partial class WatermarkTextBox : UserControl
    {
        public event TextChangedEventHandler? TextChanged;

        public WatermarkTextBox()
        {
            InitializeComponent();
        }


        public new bool IsEnabled
        {
            get => (bool)GetValue(IsEnabledProperty);
            set => SetValue(IsEnabledProperty, value);
        }

        public static new readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register(
                nameof(IsEnabled), typeof(bool), typeof(WatermarkTextBox), new PropertyMetadata(default(bool)));

        public new double Opacity
        {
            get => (double)GetValue(OpacityProperty);
            set => SetValue(OpacityProperty, value);
        }

        public static new readonly DependencyProperty OpacityProperty =
            DependencyProperty.Register(
                nameof(Opacity), typeof(double), typeof(WatermarkTextBox), new PropertyMetadata(default(double)));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set
            {
                SetValue(TextProperty, value);
                UpdateWatermarkVisibility();
            }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text), typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(string.Empty));

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(
                nameof(Placeholder), typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(string.Empty));

        private void UserControl_Loaded(object sender, RoutedEventArgs e) =>
            UpdateWatermarkVisibility();

        private void Grid_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e) =>
            UpdateWatermarkVisibility();

        private void UpdateWatermarkVisibility()
        {
            if (Watermark is null || Txt is null)
            {
                return;
            }

            Watermark.Visibility = string.IsNullOrEmpty(Text) && !Txt.IsFocused && Root.IsEnabled
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            Watermark.Visibility = Visibility.Collapsed;
            Txt.SelectAll();
        }

        private void Txt_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Txt.IsFocused)
            {
                return;
            }
            e.Handled = true;
            Txt.Focus();
        }

        private void Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextChanged is null)
            {
                return;
            }

            Text = Txt.Text;
            TextChanged(sender, e);
        }

        private async void Watermark_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Watermark.Visibility = Visibility.Collapsed;
            await Task.Delay(50);
            Txt.Focus();
        }

        private void Root_DragEnter(object sender, DragEventArgs e) =>
            Watermark.Visibility = Visibility.Collapsed;

        private void Root_PreviewGotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            if (e.NewFocus == this)
            {
                Txt.Focus();
                e.Handled = true;
            }
        }

    }
}
