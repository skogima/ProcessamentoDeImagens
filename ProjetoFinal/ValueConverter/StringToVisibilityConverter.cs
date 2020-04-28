using System;
using System.Globalization;
using System.Windows;

namespace ProjetoFinal
{
    public class StringToVisibilityConverter : BaseValueConverter<StringToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string v = value?.ToString();
            switch (v)
            {
                case nameof(Binarizacao):
                    return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
