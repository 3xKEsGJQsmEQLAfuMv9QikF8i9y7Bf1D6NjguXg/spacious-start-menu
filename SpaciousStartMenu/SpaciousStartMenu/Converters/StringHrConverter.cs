using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaciousStartMenu.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    internal class StringHrConverter : IValueConverter
    {
        private const string _hr = "---------------";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null ||
                value is not string str)
            {
                return _hr;
            }

            if (string.IsNullOrEmpty(str))
            {
                return _hr;
            }

            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
