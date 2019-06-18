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

        public static Tuple Vector(double x, double y, double z)
        {
            return new Tuple(x, y, z, 0.0);
        }

        public static Tuple Zero()
        {
            return new Tuple(0.0, 0.0, 0.0, 0.0);
        }

        public static Tuple operator- (Tuple tuple)
        {
            tuple.x = -tuple.x;
            tuple.y = -tuple.y;
            tuple.z = -tuple.z;
            tuple.w = tuple.w;

            return tuple;
        }

        public static Tuple operator *(double scalar, Tuple tuple)
        {
            tuple.x = scalar * tuple.x;
            tuple.y = scalar * tuple.y;
            tuple.z = scalar * tuple.z;
            tuple.w = tuple.w;

            return tuple;
        }

        public static Tuple operator *(Tuple tuple, double scalar)
        {
            return scalar * tuple;
        }

        public static Tuple operator /(Tuple tuple, double scalar)
        {
            tuple.x = tuple.x / scalar;
            tuple.y = tuple.y / scalar;
            tuple.z = tuple.z / scalar;
            tuple.w = tuple.w;

            return tuple;
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

            if (this.Compare(this.w, -1.0))
            {
                throw new System.InvalidOperationException("Substract a point of a vector is an invalid operation");
            }

            return this;
        }

        public Double Length()
        {

            return (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)));
        }

        public Tuple Normalize()
        {
            //TODO: Maybe this should return another object or the same object. Study what would be optimal.
            //TDOO: filter to normalize only vectors
            var length = this.Length();

            x = x/length;
            y = y/length;
            z = z/length;


            return this;
        }

        #endregion
    }
   
}
