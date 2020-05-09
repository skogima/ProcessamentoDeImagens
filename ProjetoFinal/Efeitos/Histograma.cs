using System.Collections.Generic;
using System.Drawing;

namespace ProjetoFinal
{
    public class Histograma
    {
        private enum Canal
        {
            Vermelho,
            Verde,
            Azul,
            Cinza
        }

        private static double[] GerarHistograma(Bitmap bitmap, Canal canal)
        {
            var histograma = new double[256];

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);

                    switch (canal)
                    {
                        case Canal.Vermelho:
                            histograma[c.R]++;
                            break;
                        case Canal.Verde:
                            histograma[c.G]++;
                            break;
                        case Canal.Azul:
                            histograma[c.B]++;
                            break;
                        case Canal.Cinza:
                            histograma[c.R]++;
                            break;
                        default:
                            break;
                    }
                }
            }
            return histograma;
        }

        public static double[] GerarHistogramaVermelho(Bitmap bitmap)
        {
            return GerarHistograma(bitmap, Canal.Vermelho);
        }

        public static double[] GerarHistogramaAzul(Bitmap bitmap)
        {
            return GerarHistograma(bitmap, Canal.Azul);
        }

        public static double[] GerarHistogramaVerde(Bitmap bitmap)
        {
            return GerarHistograma(bitmap, Canal.Verde);
        }
        public static double[] GerarHistogramaCinza(Bitmap bitmap)
        {
            return GerarHistograma(bitmap, Canal.Cinza);
        }

    }
}
