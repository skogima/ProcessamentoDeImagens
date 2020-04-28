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
        private static Dictionary<int, int> GerarHistograma(Bitmap bitmap, Canal canal)
        {
            var histograma = new Dictionary<int, int>();
            for (int i = 0; i < 256; i++)
            {
                histograma.Add(i, 0);
            }
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);

                    switch (canal)
                    {
                        case Canal.Vermelho:
                            histograma[c.R] += 1;
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

        public static Dictionary<int, int> GerarHistogramaVermelho(Bitmap bitmap)
        {
            return GerarHistograma(bitmap, Canal.Vermelho);
        }

        public static Dictionary<int, int> GerarHistogramaAzul(Bitmap bitmap)
        {
            return GerarHistograma(bitmap, Canal.Azul);
        }

        public static Dictionary<int, int> GerarHistogramaVerde(Bitmap bitmap)
        {
            return GerarHistograma(bitmap, Canal.Verde);
        }
        public static Dictionary<int, int> GerarHistogramaCinza(Bitmap bitmap)
        {
            return GerarHistograma(bitmap, Canal.Cinza);
        }

    }
}
