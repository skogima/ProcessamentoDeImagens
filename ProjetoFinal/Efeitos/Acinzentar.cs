using System.Drawing;

namespace ProjetoFinal
{
    public class Acinzentar : IEfeito
    {
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            return AcinzentarImagem(bitmap);
        }

        public Bitmap AcinzentarImagem(Bitmap bitmap)
        {
            Bitmap novaImagem = new Bitmap(bitmap.Width, bitmap.Height);

            for (int i = 0; i < novaImagem.Width; i++)
            {
                for (int j = 0; j < novaImagem.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    int cinza = (c.R + c.G + c.B) / 3;
                    novaImagem.SetPixel(i, j, Color.FromArgb(cinza, cinza, cinza));
                }
            }
            return novaImagem;
        }
    }
}
