using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ProjetoFinal
{
    public class BoolAndMultiConverter : MarkupExtension, IMultiValueConverter
    {
        private BoolAndMultiConverter instance;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = true;
            foreach (var item in values)
            {
                if (item is bool)
                {
                    if (!(bool)item) result = false;
                }
            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return instance ?? (instance = new BoolAndMultiConverter());
        }
    }
}
