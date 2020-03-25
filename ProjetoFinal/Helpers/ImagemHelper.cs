using System;
using System.Drawing;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace ProjetoFinal
{
    public class ImagemHelper
    {
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject(IntPtr value);

        public static Bitmap ToBitmap(string source)
        {
            return new Bitmap(source);
        }

        public static BitmapSource ToBitmapSource(Bitmap bitmap)
        {
            var bmp = new Bitmap(bitmap);
            IntPtr bmpPt = bmp.GetHbitmap();
            BitmapSource bitmapSource =
             System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                   bmpPt,
                   IntPtr.Zero,
                   Int32Rect.Empty,
                   BitmapSizeOptions.FromEmptyOptions());

            bitmapSource.Freeze();
            DeleteObject(bmpPt);

            return bitmapSource;
        }
    }
}
