using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaciousStartMenu.Converters
{
    [ValueConversion(typeof(bool), typeof(double))]
    internal class BooleanToReverseDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool b ||
                parameter is null)
            {
                return 1.0;
            }

            if (double.TryParse(parameter.ToString(), out double param))
            {
                return b ? 1.0 : param;
            }
            else
            {
                return 1.0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

    }
}
