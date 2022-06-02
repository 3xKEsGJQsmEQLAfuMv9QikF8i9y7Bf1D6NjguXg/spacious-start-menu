using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SpaciousStartMenu.Converters
{
    [ValueConversion(typeof(bool), typeof(Brushes))]
    internal class DeleteColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool b)
            {
                return Brushes.White;
            }

            return b ? Brushes.Salmon : Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
