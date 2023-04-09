using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work1
{
    internal class Median : MatrixFilter
    {
        int sizeX;
        int sizeY;
        public Median()
        {
            sizeX = 3;
            sizeY = 3;
            kernel = new float[sizeX, sizeY];
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = (int)(kernel.GetLength(0) * 0.5);
            int radiusY = (int)(kernel.GetLength(1) * 0.5);
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            int sizeF = sizeX * sizeY;
            float[] massP = new float[sizeF];
            float[] massR = new float[sizeF];
            float[] massG = new float[sizeF];
            float[] massB = new float[sizeF];
            int i = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    massR[i] = neighborColor.R;
                    massG[i] = neighborColor.G;
                    massB[i] = neighborColor.B;
                    massP[i] = (int)((neighborColor.R * 0.36) + (neighborColor.G * 0.53) + (neighborColor.B * 0.11));
                    i++;
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }
            float temp;
            for (int g = 0; g < sizeF; g++)
            {
                for (int j = g + 1; j < sizeF; j++)
                {
                    if (massP[g] > massP[j])
                    {
                        temp = massR[g];
                        massR[g] = massR[j];
                        massR[j] = temp;

                        temp = massG[g];
                        massG[g] = massG[j];
                        massG[j] = temp;

                        temp = massB[g];
                        massB[g] = massB[j];
                        massB[j] = temp;

                        temp = massP[g];
                        massP[g] = massP[j];
                        massP[j] = temp;
                    }
                }
            }
            int h = sizeF / 2;
            return Color.FromArgb(Clamp((int)massR[h], 0, 255), Clamp((int)massG[h], 0, 255), Clamp((int)massB[h], 0, 255));
        }
    }
}
