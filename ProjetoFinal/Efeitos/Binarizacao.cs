using System;
using System.Drawing;

namespace ProjetoFinal
{
    public class Binarizacao : IEfeito
    {
        private readonly Color branco = Color.FromArgb(255, 255, 255);
        private readonly Color preto = Color.FromArgb(0, 0, 0);
        private const int limiarPadrao = 127;
        
        private Color Binarizar(Color pixel, int limiar)
        {
            int media = (int)Math.Round((pixel.R + pixel.G + pixel.B) / 3.0);
            if (media >= limiar)
                return preto;
            return branco;
        }

        /// <summary>
        /// Aplica o efeito de binarização a imagem desejada.
        /// </summary>
        /// <param name="bitmap">A imagem a ser processada.</param>
        /// <param name="parameter">A limiar da binarização. Se o valor for nulo, o padrão será 127</param>
        /// <returns>A imagem processada</returns>
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            int limiar = limiarPadrao;
            if (parameter != null)
                limiar = Convert.ToInt32(parameter);

            return BinarizarImagem(bitmap, limiar);
        }

        public Bitmap BinarizarImagem(Bitmap bitmap, int limiar)
        {
            Bitmap novaImagem = new Bitmap(bitmap.Width, bitmap.Height);

            for (int i = 0; i < novaImagem.Width; i++)
            {
                for (int j = 0; j < novaImagem.Height; j++)
                {
                    Color c = Binarizar(bitmap.GetPixel(i, j), limiar);
                    novaImagem.SetPixel(i, j, c);
                }
            }
            return novaImagem;
        }
    }
}
