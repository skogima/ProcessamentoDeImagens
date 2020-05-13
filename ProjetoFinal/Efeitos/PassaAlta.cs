using PropertyChanged;
using System;
using System.Drawing;

namespace ProjetoFinal
{
    public class PassaAlta : IEfeito
    {
        private int CalcularSqrt(Bitmap bmp, int i, int j, double escala, OperadorPassaAlta kernel)
        {
            int Rx = 0, Ry = 0;
            int Gx = 0, Gy = 0;
            int Bx = 0, By = 0;
            int ki = 0, kj = 0;

            for (int mi = (i - 1); mi <= (i + 1); mi++)
            {
                for (int mj = (j - 1); mj <= (j + 1); mj++)
                {
                    Color color = bmp.GetPixel(mi, mj);

                    Rx += color.R * kernel.X[ki, kj];
                    Gx += color.B * kernel.X[ki, kj];
                    Bx += color.G * kernel.X[ki, kj];
                    Ry += color.R * kernel.Y[ki, kj];
                    Gy += color.B * kernel.Y[ki, kj];
                    By += color.G * kernel.Y[ki, kj];

                    kj++;
                }
                ki++;
                kj = 0;
            }
            var mr = Math.Sqrt(Math.Pow(Rx, 2) + Math.Pow(Ry, 2)) / escala;
            var mg = Math.Sqrt(Math.Pow(Gx, 2) + Math.Pow(Gy, 2)) / escala;
            var mb = Math.Sqrt(Math.Pow(Bx, 2) + Math.Pow(By, 2)) / escala;

            double media = (mr + mg + mb) / 3.0;
            if (media > 255) media = 255;

            return (int)media;
        }

        private int Calcular(Bitmap bmp, int i, int j, double escala, OperadorPassaAlta kernel)
        {
            int somaR = 0, somaG = 0, somaB = 0;
            int ki = 0, kj = 0;
            for (int mi = (i - 1); mi <= (i + 1); mi++)
            {
                for (int mj = (j - 1); mj <= (j + 1); mj++)
                {
                    Color color = bmp.GetPixel(mi, mj);

                    somaR += color.R * kernel.X[ki, kj] + color.R * kernel.Y[ki, kj];
                    somaG += color.G * kernel.X[ki, kj] + color.G * kernel.Y[ki, kj];
                    somaB += color.B * kernel.X[ki, kj] + color.B * kernel.Y[ki, kj];
                    
                    kj++;
                }
                ki++;
                kj = 0;
            }
            double media = (somaR + somaB + somaG) / 3.0;
 

            if (media > 255) media = 255;
            else if (media < 0) media = 0;

            return (int)media;
        }

        private int CalcularLaplace(Bitmap bmp, int i, int j, OperadorPassaAlta kernel)
        {
            int somaR = 0, somaG = 0, somaB = 0;
            int ki = 0, kj = 0;
            for (int mi = (i - 1); mi <= (i + 1); mi++)
            {
                for (int mj = (j - 1); mj <= (j + 1); mj++)
                {

                    somaR += bmp.GetPixel(mi, mj).R * kernel.X[ki, kj];
                    somaG += bmp.GetPixel(mi, mj).G * kernel.X[ki, kj];
                    somaB += bmp.GetPixel(mi, mj).B * kernel.X[ki, kj];
                    kj++;
                }
                ki++;
                kj = 0;
            }
            int media = (int)Math.Round((somaR + somaB + somaG) / 3.0);
            if (media < 0) media = 0;
            if (media > 255) media = 255;
            return media;
        }

        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            var p = parameter?.ToString();
            Mascara mascara = (Mascara)Enum.Parse(typeof(Mascara), p ?? nameof(Mascara.Prewitt));
            OperadorPassaAlta kernel = MascaraHelper.GetKernel(mascara);
            double escala = (double)MascaraHelper.GetFatorEscala(mascara);

            Bitmap bm = new Bitmap(bitmap.Width, bitmap.Height);
            
            for (int i = 1; i < bitmap.Width - 1; i++)
            {
                for (int j = 1; j < bitmap.Height - 1; j++)
                {
                    int c = 0;
                    if (mascara == Mascara.LaPlaciano)
                        c = CalcularLaplace(bitmap, i, j, kernel);
                    else
                        c = Calcular(bitmap, i, j, escala, kernel);

                    bm.SetPixel(i, j, Color.FromArgb(c, c, c));
                }
            }
            return bm;
        }
    }
}