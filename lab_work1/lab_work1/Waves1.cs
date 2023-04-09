using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work1
{
    internal class Waves1 : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            try
            {
                return sourceImage.GetPixel((int)(x + (20 * Math.Sin((2 * Math.PI * y) / 60))), y);
            }
            catch
            {
                return Color.FromArgb(0, 0, 0);
            }
        }
    }
}
