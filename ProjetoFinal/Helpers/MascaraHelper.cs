namespace ProjetoFinal
{
    public class MascaraHelper
    {
        public static int[,] Prewitt { get; private set; } = new int[3, 3] 
        { 
            { 1, 1, 1 }, 
            { 1, -2, 1 }, 
            { -1, -1, -1 } 
        };
        public static int[,] Kirsch { get; private set; } = new int[3, 3] 
        { 
            { 5, 5, 5 }, 
            { -3, 0, -3 }, 
            { -3, -3, -3 } 
        };
        public static int[,] Robinson3 { get; private set; } = new int[3, 3] 
        { 
            { 1, 1, 1 }, 
            { 0, 0, 0 },
            { -1, -1, -1 } 
        };
        public static int[,] Robinson5 { get; private set; } = new int[3, 3] 
        { 
            { 1, 2, 1 },
            { 0, 0, 0 }, 
            { -1, -2, -1 } 
        };
    }
}
