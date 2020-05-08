using System;
using System.Drawing;

namespace ProjetoFinal
{
    public class PassaAlta : IEfeito
    {
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            var p = parameter?.ToString();
            Mascara mascara = (Mascara)Enum.Parse(typeof(Mascara), p ?? nameof(Mascara.Prewitt));
            int[,] kernel = MascaraHelper.GetKernel(mascara);
            int escala = MascaraHelper.GetFatorEscala(mascara);

            Bitmap bm = new Bitmap(bitmap.Width, bitmap.Height);
            int somaR, somaG, somaB;
            int ki, kj;

            for (int i = 1; i < bitmap.Width - 1; i++)
            {
                for (int j = 1; j < bitmap.Height - 1; j++)
                {
                    somaR = somaG = somaB = 0;
                    ki = kj = 0;
                    for (int mi = (i - 1); mi <= (i + 1); mi++)
                    {
                        for (int mj = (j - 1); mj <= (j + 1); mj++)
                        {
                            somaR += bitmap.GetPixel(mi, mj).R * kernel[ki, kj];
                            somaG += bitmap.GetPixel(mi, mj).G * kernel[ki, kj];
                            somaB += bitmap.GetPixel(mi, mj).B * kernel[ki, kj];
                            kj++;
                        }
                        ki++;
                        kj = 0;
                    }
                    int media = (int)Math.Round((somaR + somaB + somaG) / 3.0);
                    media /= escala;

                    if (media > 255)
                        media = 255;
                    else if (media < 0)
                        media = 0;
                   
                    bm.SetPixel(i, j, Color.FromArgb(media, media, media));
                }
            }
            return bm;
        }
    }
}