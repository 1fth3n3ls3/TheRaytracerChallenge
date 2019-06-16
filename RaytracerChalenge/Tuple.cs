using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Raytracer
{

    public interface ITuple
    {
        double x { get; }
        double y { get; }
        double z { get; }
        double w { get; }

        bool IsVector();
        bool IsPoint();
    }

    public class Tuple : ITuple
    {
        private const double Epsilon = 0.00001;

        #region Fields
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double w { get; set; }
        #endregion

        #region Constructor
        public Tuple(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        #endregion
        #region Static Methods
        static public Tuple Point(double x, double y, double z)
        {
            return new Tuple(x, y, z, 1.0);
        }

        static public Tuple Vector(double x, double y, double z)
        {
            return new Tuple(x, y, z, 0.0);
        }
        #endregion

        #region Methods
        public bool IsVector()
        {
            return this.w == 0.0;
        }

        public bool IsPoint()
        {
            return this.w == 1.0;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Tuple t = (Tuple)obj;
                return Compare(x, t.x) && Compare(y, t.y) && Compare(z, t.z) && Compare(w, t.w);
            }
        }

        private bool Compare(double a, double b)
        {
            var difference = Math.Abs(a - b);
            return Epsilon >= difference;
        }

        public Tuple Add(Tuple t)
        {
            this.x += t.x;
            this.y += t.y;
            this.z += t.z;
            this.w += t.w;

            if (this.Compare(this.w, 2.0))
            {
                throw new System.InvalidOperationException("Sum 2 points is an invalid operation");
            }

            return this;
        }

        public Tuple Substract(Tuple t)
        {
            this.x -= t.x;
            this.y -= t.y;
            this.z -= t.z;
            this.w -= t.w;

            return this;
        }
        #endregion
    }
   
}
