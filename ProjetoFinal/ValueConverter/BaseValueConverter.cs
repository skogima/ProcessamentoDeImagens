using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ProjetoFinal
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter 
        where T : class, new()
    {
        private T converter;
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new T());
        }
    }
}
