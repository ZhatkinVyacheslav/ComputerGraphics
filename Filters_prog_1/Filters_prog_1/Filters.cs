using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Filters_prog_1
{
   abstract class Filters
    {

        public int Clamp(int value, int min, int max)
        { 
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        protected abstract Color calculateNewPixelColor(Bitmap sourseImage, int x, int y);

        public Bitmap processImage(Bitmap sourseImage)
        {
            Bitmap resultImage = new Bitmap(sourseImage.Width, sourseImage.Height);
            for(int i = 0; i < sourseImage.Width; i++)
            {
                for (int j = 0; j < sourseImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourseImage, i, j));
                }
            }

            return resultImage;
        }

    }

    class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            Color sourseColor = sourseImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourseColor.R, 255 - sourseColor.G, 255 - sourseColor.B);

            return resultColor;
        }
    }

}
