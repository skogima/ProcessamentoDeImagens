using System;
using System.Collections.Generic;
using System.Drawing;

namespace ProjetoFinal
{
    public class Equalizacao : IEfeito
    {
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            var resultado = new Bitmap(bitmap.Width, bitmap.Height);
            var auxiliar = new int[3, 256];
            var novo = new int[3, 256];
            int ideal = (bitmap.Height * bitmap.Width) / 256;

            for (int j = 0; j < resultado.Height; j++)
            {
                for (int i = 0; i < resultado.Width; i++)
                {
                    var cor = bitmap.GetPixel(i, j);
                    auxiliar[0, cor.R]++;
                    auxiliar[1, cor.G]++;
                    auxiliar[2, cor.B]++;
                }
            }
            int[] auxiliarValor = new int[3];
            for (int m = 0; m < auxiliar.GetLength(0); m++)
            {
                for (int i = 0; i < auxiliar.GetLength(1); i++)
                {
                    auxiliarValor[m] += auxiliar[m, i];
                    var valor = auxiliarValor[m] / ideal - 1;

                    if (valor > 0)
                        novo[m, i] = (valor > 255) ? 255 : valor;
                }
            }

            for (int j = 0; j < resultado.Height; j++)
            {
                for (int i = 0; i < resultado.Width; i++)
                {
                    var cor = bitmap.GetPixel(i, j);
                    resultado.SetPixel(i, j, Color.FromArgb(novo[0, cor.R], novo[1, cor.G], novo[2, cor.B]));
                }
            }

            return resultado;
        }
    }
}
