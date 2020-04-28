using System;
using System.Drawing;

namespace ProjetoFinal
{
    public class Quantizacao : IEfeito
    {
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            Bitmap novaImagem = new Bitmap(bitmap.Width, bitmap.Height);
            int divisao = Convert.ToInt32(parameter);
            divisao = 256 / divisao;
            int xR, xG, xB;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    xR = c.R % divisao;
                    xG = c.G % divisao;
                    xB = c.B % divisao;

                    xR = divisao - xR - 1;
                    xG = divisao - xG - 1;
                    xB = divisao - xB - 1;

                    Color novaCor = Color.FromArgb(c.R + xR, c.G + xG, c.B + xB);
                    novaImagem.SetPixel(i, j, novaCor);
                }
            }

            return novaImagem;
        }
    }
}
