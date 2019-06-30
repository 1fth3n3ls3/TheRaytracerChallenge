using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer
{
    public class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Pixel[,] Pixels { get; private set; }
        public Canvas(int width, int height)
        {
            Height = height;
            Width = width;
            // initialize all pixel values.
            Pixels = new Pixel[width,height];
            for (int i = 0; i < width * height; i++) Pixels[i % width, i / width] = new Pixel();
        }


    }

    public class Pixel
    {
        public Color Color { get; set; }
        public Pixel()
        {
            Color = new Color(0, 0, 0, 1);
        }
        public Pixel(Color color)
        {
            Color = color;
        }

    }
}
