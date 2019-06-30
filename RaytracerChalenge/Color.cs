using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer
{
    public class Color
    {
        private const double Epsilon = 0.00001;

        #region Properties
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }
        public double A { get; set; }
        #endregion

        #region Constructor
        public Color(double r, double g, double b, double a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        #endregion
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Color c = (Color)obj;
                return Compare(R, c.R) && Compare(G, c.G) && Compare(B, c.B) && Compare(A, c.A);
            }
        }

        private bool Compare(double a, double b)
        {
            var difference = Math.Abs(a - b);
            return Epsilon >= difference;
        }

        #region Operators
        public static Color operator +(Color c1, Color c2)
        {
            return new Color(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B, c1.A + c2.A);
        }

        public static Color operator -(Color c1, Color c2)
        {
            return new Color(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B, c1.A - c2.A);
        }

        public static Color operator *(int scalar, Color c)
        {
            return new Color(scalar * c.R, scalar * c.G, scalar * c.B, scalar * c.A);
        }

        public static Color operator *(Color c, int scalar)
        {
            return scalar * c;
        }

        public static Color operator *(Color c1, Color c2)
        {
            return new Color(c1.R * c2.R, c1.G * c2.G, c1.B * c2.B, c1.A * c2.A);
        }
        #endregion

    }
}
