using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SpaciousStartMenu.Converters
{
    [ValueConversion(typeof(string), typeof(Brushes))]
    internal class StringToGrpTitleColorConverter : IValueConverter
    {
        private static readonly SolidColorBrush _groupTitleBrush = new (Color.FromArgb(0xFF, 0x3D, 0xFF, 0xFF));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null ? _groupTitleBrush : Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
