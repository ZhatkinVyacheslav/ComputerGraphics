﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work1
{
    internal class Waves2 : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            try
            {
                return sourceImage.GetPixel(x, (int)(y + (20 * Math.Sin(2 * Math.PI * x / 60))));
            }
            catch
            {
                return Color.FromArgb(0, 0, 0);
            }
        }
    }
}
