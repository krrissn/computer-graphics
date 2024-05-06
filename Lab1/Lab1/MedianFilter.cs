using System;
using System.Drawing;

namespace Lab1
{
    public class MedianFilter
    {
        public Bitmap medianFiltering(Bitmap image, int filterSize)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            int radius = filterSize / 2;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color[] neighbors = new Color[filterSize * filterSize];
                    int index = 0;

                    for (int i = -radius; i <= radius; i++)
                    {
                        for (int j = -radius; j <= radius; j++)
                        {
                            int newX = Math.Min(Math.Max(x + i, 0), image.Width - 1);
                            int newY = Math.Min(Math.Max(y + j, 0), image.Height - 1);
                            neighbors[index++] = image.GetPixel(newX, newY);
                        }
                    }

                    Array.Sort(neighbors, (a, b) => a.GetBrightness().CompareTo(b.GetBrightness()));
                    Color medianColor = neighbors[neighbors.Length / 2];
                    result.SetPixel(x, y, medianColor);
                }
            }

            return result;

        }

    }

}
