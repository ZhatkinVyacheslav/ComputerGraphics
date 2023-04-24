using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work1
{
    internal class Transfer : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (x + 50 < sourceImage.Width)
            { 
                return sourceImage.GetPixel(x + 50, y);
            }
            return Color.FromArgb(0, 0, 0);
        }
    }
}
