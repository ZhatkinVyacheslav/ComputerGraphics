using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work1
{
    struct iColor
    {
        public float r;
        public float g;
        public float b;
        public iColor(float _r, float _g, float _b)
        {
            r = _r;
            g = _g;
            b = _b;
        }
    }

    internal class Sobel : MatrixFilter
    {
        protected float[,] kernelX = null;
        protected float[,] kernelY = null;
        public Sobel()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernelX = new float[sizeX, sizeY];
            kernelY = new float[sizeX, sizeY];
            kernelX[0, 0] = -1;
            kernelX[0, 1] = 0;
            kernelX[0, 2] = 1;
            kernelX[1, 0] = -2;
            kernelX[1, 1] = 0;
            kernelX[1, 2] = 2;
            kernelX[2, 0] = -1;
            kernelX[2, 1] = 0;
            kernelX[2, 2] = 1;

            kernelY[0, 0] = -1;
            kernelY[0, 1] = -2;
            kernelY[0, 2] = -1;
            kernelY[1, 0] = 0;
            kernelY[1, 1] = 0;
            kernelY[1, 2] = 0;
            kernelY[2, 0] = 1;
            kernelY[2, 1] = 2;
            kernelY[2, 2] = 1;
        }
        protected iColor calculateNewPixelColorOne(Bitmap sourceImage, int x, int y, float[,] kernel)
        {
            int radiusX = (int)(kernel.GetLength(0) * 0.5);
            int radiusY = (int)(kernel.GetLength(1) * 0.5);
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }
            return new iColor(resultR, resultG, resultB);
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            iColor cx = calculateNewPixelColorOne(sourceImage, x, y, kernelX);
            iColor cy = calculateNewPixelColorOne(sourceImage, x, y, kernelY);
            Color cxy = Color.FromArgb(
                Clamp((int)Math.Sqrt(cx.r * cx.r + cy.r * cy.r), 0, 255),
                Clamp((int)Math.Sqrt(cx.g * cx.g + cy.g * cy.g), 0, 255),
                Clamp((int)Math.Sqrt(cx.b * cx.b + cy.b * cy.b), 0, 255)
            );
            return cxy;
        }
    }
}