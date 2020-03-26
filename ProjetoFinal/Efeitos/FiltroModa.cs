using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace ProjetoFinal
{
    public class FiltroModa : IEfeito
    {
        public Bitmap AplicarEfeito(Bitmap bitmap, object parameter)
        {
            Bitmap bm = new Bitmap(bitmap.Width, bitmap.Height);

            var valuesR = new Dictionary<int, int>();
            var valuesG = new Dictionary<int, int>();
            var valuesB = new Dictionary<int, int>();

            for (int i = 1; i < bitmap.Width - 1; i++)
            {
                for (int j = 1; j < bitmap.Height - 1; j++)
                {
                    int freqR = 1;
                    int freqG = 1;
                    int freqB = 1;
                    for (int ki = (i - 1); ki <= (i + 1); ki++)
                    {
                        for (int kj = (j - 1); kj <= (j + 1); kj++)
                        {
                            Color c = bitmap.GetPixel(ki, kj);

                            if (valuesR.ContainsKey(c.R))
                                valuesR[c.R]++;
                            else
                                valuesR.Add(c.R, freqR);

                            if (valuesG.ContainsKey(c.G))
                                valuesG[c.G]++;
                            else
                                valuesG.Add(c.G, freqG);

                            if (valuesB.ContainsKey(c.B))
                                valuesB[c.B]++;
                            else
                                valuesB.Add(c.B, freqB);
                        }
                    }

                    int r = valuesR.OrderByDescending(x => x.Value).Select(x => x.Key).First();
                    int g = valuesG.OrderByDescending(x => x.Value).Select(x => x.Key).First();
                    int b = valuesB.OrderByDescending(x => x.Value).Select(x => x.Key).First();

                    bm.SetPixel(i, j, Color.FromArgb(r, g, b));

                    valuesR.Clear(); valuesG.Clear(); valuesB.Clear();
                }
            }
            return bm;
        }
    }
}
