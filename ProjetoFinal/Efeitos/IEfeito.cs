using System;
using System.Drawing;

namespace ProjetoFinal
{
    interface IEfeito
    {
        Bitmap AplicarEfeito(Bitmap bitmap, object parameter);
    }
}
