using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Raytracer
{

    public interface ITuple
    {
        #region Properties
        double X { get; }
        double Y { get; }
        double Z { get; }
        double W { get; }

        #endregion


        bool IsVector();
        bool IsPoint();
    }

    public class Tuple : ITuple
    {
        private const double Epsilon = 0.00001;

        #region Properties
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }
        #endregion

        #region Constructor
        public Tuple(double X, double Y, double Z, double W)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.W = W;
        }

        #endregion
        #region Factories
        static public Tuple Point(double X, double Y, double Z)
        {
            return new Tuple(X, Y, Z, 1.0);
        }

        public static Tuple Vector(double X, double Y, double Z)
        {
            return new Tuple(X, Y, Z, 0.0);
        }

        public static Tuple Zero()
        {
            return new Tuple(0.0, 0.0, 0.0, 0.0);
        }
        #endregion

        #region Operators
        public static Tuple operator- (Tuple tuple)
        {
            return new Tuple(-tuple.X, -tuple.Y, -tuple.Z, tuple.W);
        }

        public static Tuple operator+ (Tuple a, Tuple b)
        {
            var tuple = new Tuple(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);

            if (this.Compare(tuple.W, 2.0))
            {
                throw new System.InvalidOperationException("Sum 2 points is an invalid operation");
            }

            return tuple;
        }

        public static Tuple operator *(double scalar, Tuple tuple)
        {
            return new Tuple(tuple.X * scalar, tuple.Y * scalar, tuple.Z * scalar, tuple.W);
        }

        public static Tuple operator *(Tuple tuple, double scalar)
        {
            return scalar * tuple;
        }

        public static Tuple operator /(Tuple tuple, double scalar)
        {
            return new Tuple(tuple.X / scalar, tuple.Y / scalar, tuple.Z / scalar, tuple.W);
        }
        #endregion

        #region Methods
        public bool IsVector()
        {
            return this.W == 0.0;
        }

        public bool IsPoint()
        {
            return this.W == 1.0;
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
                return Compare(X, t.X) && Compare(Y, t.Y) && Compare(Z, t.Z) && Compare(W, t.W);
            }
        }

        private bool Compare(double a, double b)
        {
            var difference = Math.Abs(a - b);
            return Epsilon >= difference;
        }

        public Tuple Add(Tuple t)
        {
            var tuple = new Tuple(X + t.X, Y + t.Y, Z + t.Z, W + t.W);

            if (this.Compare(tuple.W, 2.0))
            {
                throw new System.InvalidOperationException("Sum 2 points is an invalid operation");
            }

            return tuple;
        }

        public Tuple Substract(Tuple t)
        {
            var tuple = new Tuple(X - t.X, Y - t.Y, Z - t.Z, W - t.W);


            if (this.Compare(tuple.W, -1.0))
            {
                throw new System.InvalidOperationException("Substract a point of a vector is an invalid operation");
            }

            return tuple;
        }

        public Double Length()
        {

            return (Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)));
        }

        public Tuple Normalize()
        {
            //TODO: Maybe this should return another object or the same object. Study what would be optimal.
            //TDOO: filter to normalize only vectors
            var length = this.Length();

            return Vector(X / length, Y / length, Z / length);
        }

        public static double Dot(Tuple a, Tuple b)
        {
            return  a.X * b.X +
                    a.Y * b.Y +
                    a.Z * b.Z +
                    a.W * b.W;
        }

        public static Tuple Cross(Tuple a, Tuple b)
        {
            return Vector(a.Y * b.Z - a.Z * b.Y,
                          a.Z * b.X - a.X * b.Z,
                          a.X * b.Y - a.Y * b.X);
        }

        #endregion
    }
   
}
