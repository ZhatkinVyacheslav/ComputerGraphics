using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work1
{
    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            Color sourseColor = sourseImage.GetPixel(x, y);
            int Intensity = (int)((sourseColor.R * 0.36) + (sourseColor.G * 0.53) + (sourseColor.B * 0.11));
            Color resultColor = Color.FromArgb(Intensity, Intensity, Intensity);

            return resultColor;
        }
    }
}
    