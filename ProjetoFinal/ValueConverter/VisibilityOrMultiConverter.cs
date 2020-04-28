using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ProjetoFinal
{
    public class VisibilityOrMultiConverter : MarkupExtension, IMultiValueConverter
    {
        private VisibilityOrMultiConverter instance;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var item in values)
            {
                if (item is Visibility)
                {
                    if ((Visibility)item == Visibility.Visible)
                        return Visibility.Visible;
                }
            }

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return instance ?? (instance = new VisibilityOrMultiConverter());
        }
    }
}
