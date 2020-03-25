using System;
using System.Drawing;

namespace ProjetoFinal
{
    public class Sepia : IEfeito
    {
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            Bitmap bm = new Bitmap(bitmap.Width, bitmap.Height);
            int iR, iG, iB;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);

                    iR = (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B);
                    iG = (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B);
                    iB = (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B);

                    if (iR > 255)
                        iR = 255;
                    if (iG > 255)
                        iG = 255;
                    if (iB > 255)
                        iB = 255;

                    Color n = Color.FromArgb(iR, iG, iB);
                    bm.SetPixel(i, j, n);
                }
            }

            return bm;
        }
    }
}
