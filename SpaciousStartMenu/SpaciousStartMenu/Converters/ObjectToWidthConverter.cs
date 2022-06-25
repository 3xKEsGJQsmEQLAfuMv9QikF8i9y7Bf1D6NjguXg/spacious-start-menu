using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaciousStartMenu.Converters
{
    [ValueConversion(typeof(object), typeof(double))]
    internal class ObjectToWidthConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null ? 1 : null;
        }

        public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
