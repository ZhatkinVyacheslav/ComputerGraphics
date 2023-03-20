﻿using System;
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
            double Intensity = sourseColor.R * 0.36 + sourseColor.G * 0.53 + 0.11 * sourseColor.B;

            Color resultColor = Color.FromArgb(Clamp((int)Intensity, (int)Intensity, (int)Intensity));

            return resultColor;
        }
    }
}
