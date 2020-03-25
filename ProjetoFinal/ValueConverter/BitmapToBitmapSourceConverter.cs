using System;
using System.Drawing;
using System.Globalization;

namespace ProjetoFinal
{
    public class BitmapToBitmapSourceConverter : BaseValueConverter<BitmapToBitmapSourceConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return default;
            Bitmap b = (Bitmap)value;
            return ImagemHelper.ToBitmapSource(b);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
