namespace ProjetoFinal
{
    public class MascaraHelper
    {
        public static int[,] GetKernel(Mascara mascara)
        {
            switch (mascara)
            {
                case Mascara.Prewitt:
                    return prewitt;
                case Mascara.Kirsch:
                    return kirsch;
                case Mascara.Sobel:
                    return sobel;
                case Mascara.Robinson3:
                    return robinson3;
                case Mascara.Robinson5:
                    return robinson5;
                case Mascara.LaPlaciano:
                    return laPlaciano;
                default:
                    return prewitt;
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
                case Mascara.Robinson3:
                    return robinson3Escala;
                case Mascara.Robinson5:
                    return robinson5Escala;
                case Mascara.LaPlaciano:
                    return laplaceEscala;
                default:
                    return prewittEscala;
            }
        }

        private static int prewittEscala = 5;
        private static int[,] prewitt = new int[3, 3] 
        { 
            { 1, 1, 1 }, 
            { 1, -2, 1 }, 
            { -1, -1, -1 } 
        };

        private static int kirschEscala = 15;
        private static int[,] kirsch = new int[3, 3] 
        { 
            { 5, 5, 5 }, 
            { -3, 0, -3 }, 
            { -3, -3, -3 } 
        };

        private static int sobelEscala = 1;
        private static int[,] sobel = new int[3, 3] 
        { 
            { -1, -2, -1 }, 
            { 0, 0, 0 }, 
            { 1, 2, 1 } 
        };

        private static int robinson3Escala = 3;
        private static int[,] robinson3 = new int[3, 3] 
        { 
            { 1, 1, 1 }, 
            { 0, 0, 0 },
            { -1, -1, -1 } 
        };

        private static int robinson5Escala = 5;
        private static int[,] robinson5 = new int[3, 3] 
        { 
            { 1, 2, 1 },
            { 0, 0, 0 }, 
            { -1, -2, -1 } 
        };
        
        private static int laplaceEscala = 1;
        private static int[,] laPlaciano = new int[3, 3] 
        { 
            { 0, 1, 0 },
            { 1, -4, 1 }, 
            { 0, 1, 0 } 
        };
    }
}
