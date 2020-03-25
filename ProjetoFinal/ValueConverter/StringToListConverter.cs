using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjetoFinal
{
    public class StringToListConverter : BaseValueConverter<StringToListConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return new List<string>();
            }

            string v = value.ToString();

            if (v.Equals(typeof(InversaoCanal).Name))
            {
                return ParametersListHelper.InverterCanalList;
            }
            else if (v.Equals(typeof(FiltroMedia).Name))
            {
                return ParametersListHelper.PassaAltaList;
            }

            return new List<string>();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
