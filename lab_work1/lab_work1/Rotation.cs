using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work1
{
    internal class Rotation : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            try
            {
                return sourceImage.GetPixel((int)((x - sourceImage.Width / 2) * Math.Cos(45) - (y - sourceImage.Height / 2) * Math.Sin(45) + sourceImage.Width / 2), 
                    (int)((x - sourceImage.Width / 2) * Math.Sin(45) + (y - sourceImage.Height / 2) * Math.Cos(45)) + sourceImage.Height / 2);
            }
            catch
            {
                return Color.FromArgb(0, 0, 0);
            }
        }
    }
}
