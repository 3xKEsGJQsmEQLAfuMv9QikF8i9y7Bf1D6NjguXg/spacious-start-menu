using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace SpaciousStartMenu.Converters
{
    internal enum TrueFalseJudgeType
    {
        OrTrueToTrue,
        OrTrueToFalse,
        AndTrueToTrue,
        AndTrueToFalse,
    }

    [ValueConversion(typeof(bool), typeof(bool?))]
    internal class BooleansToBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values is null ||
                values.Length < 1 ||
                parameter is not string p)
            {
                return false;
            }

            var t = GetParameter(p);

            if (t == TrueFalseJudgeType.OrTrueToTrue)
            {
                return values.Any(x => x is bool b && b);
            }

            if (t == TrueFalseJudgeType.OrTrueToFalse)
            {
                return !values.Any(x => x is bool b && b);
            }

            return false;
        }

        private TrueFalseJudgeType GetParameter(string value)
        {
            if (!Enum.TryParse(value, out TrueFalseJudgeType t))
            {
                throw new ArgumentException("Parameter Error");
            }

            switch (t)
            {
                case TrueFalseJudgeType.OrTrueToTrue:
                    break;
                case TrueFalseJudgeType.OrTrueToFalse:
                    break;
                case TrueFalseJudgeType.AndTrueToTrue:
                    throw new NotImplementedException();
                case TrueFalseJudgeType.AndTrueToFalse:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }

            return t;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
