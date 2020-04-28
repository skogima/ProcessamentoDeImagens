using System;
using System.Drawing;

namespace ProjetoFinal
{
    public class Girar
    {
        public static Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            Sentido sentido = (Sentido)Enum.Parse(typeof(Sentido), parameter.ToString());

            switch (sentido)
            {
                case Sentido.Direita:
                    return GirarDireita(bitmap);
                case Sentido.Esquerda:
                    return GirarEsquerda(bitmap);
                case Sentido.Vertical:
                    return Inverter(bitmap);
                case Sentido.Horizontal:
                    return EspelharImagem(bitmap);
            }
            return bitmap;
        }

        private static Bitmap EspelharImagem(Bitmap bitmap)
        {
            Bitmap bit = new Bitmap(bitmap.Width, bitmap.Height);

            int width = bitmap.Width - 1;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    bit.SetPixel(width - i, j, c);
                }
            }

            return bit;
        }

        private static Bitmap Inverter(Bitmap bitmap)
        {
            Bitmap bit = new Bitmap(bitmap.Width, bitmap.Height);

            int width = bitmap.Width - 1;
            int height = bitmap.Height - 1;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    bit.SetPixel(width - i, height - j, c);
                }
            }

            return bit;
        }

        private static Bitmap GirarEsquerda(Bitmap bitmap)
        {
            Bitmap bit = new Bitmap(bitmap.Height, bitmap.Width);

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    bit.SetPixel(j, i, c);
                }
            }

            return bit;
        }

        private static Bitmap GirarDireita(Bitmap bitmap)
        {
            Bitmap bit = new Bitmap(bitmap.Height, bitmap.Width);

            int width = bit.Width - 1;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    bit.SetPixel(width - j, i, c);
                }
            }

            return bit;
        }
    }
}
