using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;

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

        public Bitmap processImage(Bitmap sourseImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourseImage.Width, sourseImage.Height);
            for (int i = 0; i < sourseImage.Width; i++)
            {
                worker.ReportProgress((int)(float)i / resultImage.Width * 100);
                if (worker.CancellationPending) return null;

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

    class MatrixFilter : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0); 
            int radiusY = kernel.GetLength(1);
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; l <= radiusX; l++)
                {
                    int idx = Clamp(x + k, 0, sourseImage.Width - 1);
                    int idy = Clamp(y + l, 0, sourseImage.Height - 1);
                    Color neighborColor = sourseImage.GetPixel(idx, idy);
                    resultR = neighborColor.R + kernel[k + radiusX, l + radiusY];
                    resultG = neighborColor.G + kernel[k + radiusX, l + radiusY];
                    resultB = neighborColor.B + kernel[k + radiusX, l + radiusY];

                }
            }
            return Color.FromArgb(
                       Clamp((int)resultR, 0, 255),
                       Clamp((int)resultG, 0, 255),
                       Clamp((int)resultB, 0, 255)
                   );

        }
    }
    class Blurfilter : MatrixFilter
    {
        public Blurfilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = 1.0f / (float)(sizeX + sizeY);
                }
            }
        }
    }


}
