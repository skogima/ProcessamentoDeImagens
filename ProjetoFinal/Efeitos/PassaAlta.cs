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
                    if (somaB < 0)
                        somaB = 0;
                    else if (somaB > 255)
                        somaB = 255;
                    if (somaR < 0)
                        somaR = 0;
                    else if (somaR > 255)
                        somaR = 255;
                    if (somaG < 0)
                        somaG = 0;
                    else if (somaG > 255)
                        somaG = 255;
                    bm.SetPixel(i, j, Color.FromArgb(somaR / escala, somaB / escala, somaG / escala));
                }
            }
            return bm;
        }
    }
}