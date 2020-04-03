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

            switch (v)
            {
                case nameof(InversaoCanal):
                    return ParametersListHelper.InverterCanalList;
                case nameof(PassaAlta):
                    return ParametersListHelper.PassaAltaList;
                case nameof(Quantizacao):
                    return ParametersListHelper.QuantizacaoCanais;
                default:
                    return new List<string>();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
