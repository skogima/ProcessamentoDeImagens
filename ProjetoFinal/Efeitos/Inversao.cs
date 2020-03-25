using System;
using System.Drawing;

namespace ProjetoFinal
{
    public class Inversao : IEfeito
    {
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            return InverterCores(bitmap);
        }

        public Bitmap InverterCores(Bitmap bitmap)
        {
            Bitmap novaImagem = new Bitmap(bitmap.Width, bitmap.Height);

            for (int i = 0; i < novaImagem.Width; i++)
            {
                for (int j = 0; j < novaImagem.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    
                    novaImagem.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            return novaImagem;
        }
    }
}
