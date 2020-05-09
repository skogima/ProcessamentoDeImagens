using System.Drawing;
using System.Collections.Generic;
using LiveCharts;
using LiveCharts.Wpf;

namespace ProjetoFinal
{
    public class HistogramaHelper : BaseViewModel
    {
        public SeriesCollection HistogramaSeries { get; set; }
        private ChartValues<double> valoresAzul, valoresVermelho, valoresVerde;

        public HistogramaHelper()
        {
            valoresAzul = new ChartValues<double>();
            valoresVermelho = new ChartValues<double>();
            valoresVerde = new ChartValues<double>();

            HistogramaSeries = new SeriesCollection
            {
                new ColumnSeries { Values = valoresAzul, ColumnPadding = 0, Fill = System.Windows.Media.Brushes.Blue },
                new ColumnSeries { Values = valoresVermelho, ColumnPadding = 0, Fill = System.Windows.Media.Brushes.Red },
                new ColumnSeries { Values = valoresVerde, ColumnPadding = 0, Fill = System.Windows.Media.Brushes.Green }
            };
        }

        public bool EstaVazio()
        {
            if (valoresAzul.Count > 0 || valoresVermelho.Count > 0 || valoresVerde.Count > 0)
                return false;
            return true;
        }

        public void Limpar()
        {
            valoresAzul.Clear();
            valoresVermelho.Clear();
            valoresVerde.Clear();
        }

        public void Calcular(Bitmap bitmap)
        {
            Limpar();

            var db = Histograma.GerarHistogramaAzul(bitmap);
            var dr = Histograma.GerarHistogramaVermelho(bitmap);
            var dg = Histograma.GerarHistogramaVerde(bitmap);

            for (int i = 0; i < db.Length; i++)
            {
                valoresAzul.Add(db[i]);
                valoresVerde.Add(dg[i]);
                valoresVermelho.Add(dr[i]);
            }

            OnPropertyChanged(nameof(HistogramaSeries));
        }
    }
}
