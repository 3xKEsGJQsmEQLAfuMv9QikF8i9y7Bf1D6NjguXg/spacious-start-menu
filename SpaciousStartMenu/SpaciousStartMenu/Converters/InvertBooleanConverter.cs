using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaciousStartMenu.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    internal class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return !b;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
