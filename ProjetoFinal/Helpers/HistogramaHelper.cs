using OxyPlot;
using System.Collections.Generic;
using System.Drawing;

namespace ProjetoFinal
{
    public class HistogramaHelper : BaseViewModel
    {
        public List<DataPoint> HistogramaR { get; set; }
        public List<DataPoint> HistogramaG { get; set; }
        public List<DataPoint> HistogramaB { get; set; }
        public HistogramaHelper()
        {
            HistogramaR = new List<DataPoint>();
            HistogramaG = new List<DataPoint>();
            HistogramaB = new List<DataPoint>();
        }

        public bool EstaVazio()
        {
            if (HistogramaR.Count > 0 || HistogramaG.Count > 0 || HistogramaB.Count > 0)
                return false;
            return true;
        }

        public void Limpar()
        {
            HistogramaB.Clear();
            HistogramaG.Clear();
            HistogramaR.Clear();
        }

        public void Calcular(Bitmap bitmap)
        {
            Limpar();

            var db = Histograma.GerarHistogramaAzul(bitmap);
            var dr = Histograma.GerarHistogramaVermelho(bitmap);
            var dg = Histograma.GerarHistogramaVerde(bitmap);

            for (int i = 0; i < db.Count; i++)
            {
                HistogramaR.Add(new DataPoint(i, dr[i]));
                HistogramaG.Add(new DataPoint(i, dg[i]));
                HistogramaB.Add(new DataPoint(i, db[i]));
            }
        }
    }
}
