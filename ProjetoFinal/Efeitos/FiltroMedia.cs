using System;
using System.Drawing;

namespace ProjetoFinal
{
    public class FiltroMedia : IEfeito
    {
        private const int escala = 9;
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            Bitmap bm = new Bitmap(bitmap.Width, bitmap.Height);
            int somaR, somaG, somaB;

            for (int i = 1; i < bitmap.Width - 1; i++)
            {
                for (int j = 1; j < bitmap.Height - 1; j++)
                {
                    somaR = somaG = somaB = 0;
                    for (int mi = (i - 1); mi <= (i + 1); mi++)
                    {
                        for (int mj = (j - 1); mj <= (j + 1); mj++)
                        {
                            somaR += bitmap.GetPixel(mi, mj).R;
                            somaG += bitmap.GetPixel(mi, mj).G;
                            somaB += bitmap.GetPixel(mi, mj).B;
                        }
                    }
              
                    bm.SetPixel(i, j, Color.FromArgb(somaR / 9, somaG / 9 , somaB / 9));
                }
            }
            return bm;
        }
    }
}