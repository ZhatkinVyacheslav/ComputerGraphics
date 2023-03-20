using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work1
{
    internal class Sepia : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            double k = 23;
            Color sourseColor = sourseImage.GetPixel(x, y);
            double Intensity = sourseColor.R * 0.36 + sourseColor.G * 0.53 + 0.11 * sourseColor.B;
            double resultR = Intensity + 2 * k;
            double resultG = Intensity + 0.5 * k;
            double resultB = Intensity + 1 * k;

            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
    }
}
