using System;
using System.Drawing;

namespace ProjetoFinal
{
    public class InversaoCanal : IEfeito
    {
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            string p = parameter.ToString();
            Canal canal = (Canal)Enum.Parse(typeof(Canal), p);

            return InverterCanal(bitmap, canal);
        }

        private Color InverterCanal(Color cor, Canal canal)
        {
            switch (canal)
            {
                case Canal.RBG:
                    return Color.FromArgb(cor.R, cor.B, cor.G);
                case Canal.BGR:
                    return Color.FromArgb(cor.B, cor.G, cor.R);
                case Canal.BRG:
                    return Color.FromArgb(cor.B, cor.R, cor.G);
                case Canal.GBR:
                    return Color.FromArgb(cor.G, cor.B, cor.R);
                case Canal.GRB:
                    return Color.FromArgb(cor.G, cor.R, cor.B);
                default:
                    return cor;
            }
        } 

        public Bitmap InverterCanal(Bitmap bitmap, Canal canal)
        {
            Bitmap novaImagem = new Bitmap(bitmap.Width, bitmap.Height);

            for (int i = 0; i < novaImagem.Width; i++)
            {
                for (int j = 0; j < novaImagem.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    novaImagem.SetPixel(i, j, InverterCanal(c, canal));
                }
            }
            return novaImagem;
        }
    }
}
