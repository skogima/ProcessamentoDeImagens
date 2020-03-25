using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjetoFinal
{
    public class ParametersListHelper
    {
        public static List<string> InverterCanalList { get; private set; } = Enum.GetNames(typeof(Canal)).ToList();
        
        public static List<string> PassaAltaList { get; private set; } = Enum.GetNames(typeof(Mascara)).ToList();

    }
}
