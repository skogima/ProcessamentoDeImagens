namespace ProjetoFinal
{
    public class OperadorPassaAlta
    {
        public int[,] X { get; set; }
        public int[,] Y { get; set; }

        public OperadorPassaAlta(int[,] x, int[,] y)
        {
            X = x;
            Y = y;
        }
    }
    public class MascaraHelper
    {
        public static OperadorPassaAlta GetKernel(Mascara mascara)
        {
            switch (mascara)
            {
                case Mascara.Prewitt:
                    return new OperadorPassaAlta(prewittx, prewitty);
                case Mascara.Kirsch:
                    return new OperadorPassaAlta(kirschx, kirschy);;
                case Mascara.Sobel:
                    return new OperadorPassaAlta(sobelX, sobelY);
                case Mascara.Robinson:
                    return new OperadorPassaAlta(robinson3x, robinson3y);
                case Mascara.LaPlaciano:
                    return new OperadorPassaAlta(laPlaciano, zero);
                default:
                    return new OperadorPassaAlta(prewittx, prewitty);
            }
        }

        public static int GetFatorEscala(Mascara mascara)
        {
            switch (mascara)
            {
                case Mascara.Prewitt:
                    return prewittEscala;
                case Mascara.Kirsch:
                    return kirschEscala;
                case Mascara.Sobel:
                    return sobelEscala;
                case Mascara.Robinson:
                    return robinson3Escala;
                case Mascara.LaPlaciano:
                    return laplaceEscala;
                default:
                    return prewittEscala;
            }
        }


        private static int prewittEscala = 5;
        private static int[,] prewitty = new int[3, 3]
        {
            { 1, 1, 1 },
            { 0, 0, 0 },
            { -1, -1, -1 }
        };
        private static int[,] prewittx = new int[3, 3]
        {
            { -1, 0, 1 },
            { -1, 0, 1 },
            { -1, 0, 1 }
        };

        private static int kirschEscala = 15;
        private static int[,] kirschx = new int[3, 3]
        {
            { 5, 5, 5 },
            { -3, 0, -3 },
            { -3, -3, -3 }
        };
        private static int[,] kirschy = new int[3, 3]
        {
            { 5, -3, -3 },
            { 5, 0, -3 },
            { 5, -3, -3 }
        };

        private static int sobelEscala = 4;
        private static int[,] sobelX = new int[3, 3]
        {
            { -1, -2, -1 },
            { 0, 0, 0 },
            { 1, 2, 1 }
        };

        private static int[,] sobelY = new int[3, 3]
        {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };


        private static int robinson3Escala = 3;
        private static int[,] robinson3x = new int[3, 3]
        {
            { 1, 1, 1 },
            { 0, 0, 0 },
            { -1, -1, -1 }
        };
        private static int[,] robinson3y = new int[3, 3]
        {
            { 1, 0, -1 },
            { 1, 0, -1 },
            { 1, 0, -1 }
        };

        private static int laplaceEscala = 1;
        private static int[,] laPlaciano = new int[3, 3] 
        {
            { 0, 1, 0 },
            { 1, -4, 1 },
            { 0, 1, 0 }
        };

        private static int[,] zero = new int[3, 3]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
    }
}
