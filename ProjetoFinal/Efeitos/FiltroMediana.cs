using System.Collections.Generic;
using System.Drawing;

namespace ProjetoFinal.Efeitos
{
    public class FiltroMediana : IEfeito
    {
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            Bitmap bm = new Bitmap(bitmap.Width, bitmap.Height);

            List<int> listR = new List<int>();
            List<int> listG = new List<int>();
            List<int> listB = new List<int>();

            for (int i = 1; i < bitmap.Width - 1; i++)
            {
                for (int j = 1; j < bitmap.Height - 1; j++)
                {

                    for (int ki = (i - 1); ki <= (i + 1); ki++)
                    {
                        for (int kj = (j - 1); kj <= (j + 1); kj++)
                        {
                            listR.Add(bitmap.GetPixel(ki, kj).R);
                            listG.Add(bitmap.GetPixel(ki, kj).G);
                            listB.Add(bitmap.GetPixel(ki, kj).B);
                        }
                    }
                    listR.Sort(); listB.Sort(); listG.Sort();

                    int r = (listR[4] + listR[5]) / 2;
                    int g = (listG[4] + listG[5]) / 2;
                    int b = (listB[4] + listB[5]) / 2;

                    bm.SetPixel(i, j, Color.FromArgb(r, g, b));

                    listR.Clear(); listB.Clear(); listG.Clear();
                }
            }
            return bm;
        }
    }
}
