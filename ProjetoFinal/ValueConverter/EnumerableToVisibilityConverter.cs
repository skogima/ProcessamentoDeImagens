using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace ProjetoFinal
{
    public class EnumerableToVisibilityConverter : BaseValueConverter<EnumerableToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable enumerable = (IEnumerable)value;
            List<string> list = (List<string>)enumerable ?? null;
            if (list?.Count == 0)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
