using NUnit.Framework;

using NUnit.Framework.Constraints;
using Raytracer;


namespace Tests
{
    public class Tests
    {
        const double Epsilon = 0.00001;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_IsVector_GivenATuppleFindOutIsVector()
        {
            ITuple tuple = new Tuple(4.3, -4.2, 3.1, 0.0);
            Assert.That(tuple.X == 4.3);
            Assert.That(tuple.Y == -4.2);
            Assert.That(tuple.Z == 3.1);
            Assert.That(tuple.W == 0.0);
            Assert.True(tuple.IsVector());
            Assert.False(tuple.IsPoint());

        }

        [Test]
        public void Test_IsPoint_GivenATuppleFindOutIsPoint()
        {
            ITuple tuple = new Tuple (4.3, -4.2, 3.1, 1.0);
            Assert.That(tuple.X == 4.3);
            Assert.That(tuple.Y == -4.2);
            Assert.That(tuple.Z == 3.1);
            Assert.That(tuple.W == 1.0);
            Assert.LessOrEqual(1.0 - tuple.W, Epsilon);
            Assert.True(tuple.IsPoint());
            Assert.False(tuple.IsVector());

        }

        [Test]
        public void Test_Vector_CheckTupleIsBuildedJustRight()
        {
            ITuple tuple = Tuple.Vector(4.3, -4.2, 3.1);
            Assert.That(tuple.X == 4.3);
            Assert.That(tuple.Y == -4.2);
            Assert.That(tuple.Z == 3.1);
            Assert.That(tuple.W == 0.0);

        }

        [Test]
        public void Test_Point_CheckTupleIsBuildedJustRight()
        {
            ITuple tuple = Tuple.Point(4.3, -4.2, 3.1);
            Assert.That(tuple.X == 4.3);
            Assert.That(tuple.Y == -4.2);
            Assert.That(tuple.Z == 3.1);
            Assert.That(tuple.W == 1.0);

        }
        [Test]
        public void Test_Equals_CheckIfTwoTuplesAreEqualInValue()
        {
            var t1 = new Tuple(4.3, -4.2, 3.1, 1.0);
            var t2 = Tuple.Point(4.3, -4.2, 3.1);

            Assert.True(t1.Equals(t2));
        }
        [Test]
        public void Test_Equals_CheckIfTwoTuplesAreDifferentInValue()
        {
            var t1 = new Tuple(4.3, -4.2, 3.1, 1.0);
            var t2 = new Tuple(4.3, -4.2001, 3.1, 1.0);

            Assert.False(t1.Equals(t2));
        }

        [Test]
        public void Test_Add_SumAVectorAndAPoint()
        {
            var t1 = Tuple.Vector(4.3, -4.2, 3.1);
            var t2 = Tuple.Point(-4.3, 4.2, -3.1);

            var result = t1.Add(t2);

            Assert.LessOrEqual(0.0 - result.X, Epsilon);
            Assert.LessOrEqual(0.0 - result.Y, Epsilon);
            Assert.LessOrEqual(0.0 - result.Z, Epsilon);

            Assert.LessOrEqual(1.0 - result.W, Epsilon);
        }

        [Test]
        public void Test_Add_SumAVectorAndAVector()
        {
            var t1 = Tuple.Vector(4.3, -4.2, 3.1);
            var t2 = Tuple.Vector(-4.3, 4.2, -3.1);

            var result = t1.Add(t2);

            Assert.LessOrEqual(0.0 - result.X, Epsilon);
            Assert.LessOrEqual(0.0 - result.Y, Epsilon);
            Assert.LessOrEqual(0.0 - result.Z, Epsilon);

            Assert.LessOrEqual(0.0 - result.W, Epsilon);
        }

        [Test]

        public void Test_Add_SumAPoinAndAPoint()
        {
            var t1 = Tuple.Point(4.3, -4.2, 3.1);
            var t2 = Tuple.Point(-4.3, 4.2, -3.1);


            //Act
            ActualValueDelegate<object> testDelegate = () => t1.Add(t2);

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<System.InvalidOperationException>());
        }
        [Test]
        public void Test_Substract_SubAPoinFromAVectorRaiseAnException()
        {
            var t1 = Tuple.Vector(4.3, -4.2, 3.1);
            var t2 = Tuple.Point(-4.3, 4.2, -3.1);


            //Act
            ActualValueDelegate<object> testDelegate = () => t1.Substract(t2);

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<System.InvalidOperationException>());
        }

        [Test]
        public void Test_NegationOperator_YouGetANegateTuple()
        {
            var t1 = new Tuple(4.3, -4.2, 3.1, 1.0);
            var result = -t1;
            Assert.LessOrEqual(-4.3 - result.X, Epsilon);
            Assert.LessOrEqual(4.2 - result.Y, Epsilon);
            Assert.LessOrEqual(-3.1 - result.Z, Epsilon);

            Assert.LessOrEqual(1.0 - result.W, Epsilon);
        }

        [Test]
        public void Test_ScalarMultiplication_GetDoubleLongituded()
        {
            var t1 = new Tuple(4.3, -4.2, 3.1, 1.0);
            var result = 2 * t1;
            Assert.LessOrEqual(8.6 - result.X, Epsilon);
            Assert.LessOrEqual(-8.4 - result.Y, Epsilon);
            Assert.LessOrEqual(6.2 - result.Z, Epsilon);

            Assert.LessOrEqual(1.0 - result.W, Epsilon);
        }

        [Test]
        public void Test_ScalarDivision_GetHalfLongituded()
        {
            var t1 = new Tuple(4.3, -4.2, 3.1, 1.0);
            t1 = t1 / 2;
            Assert.LessOrEqual(2.15 - t1.X, Epsilon);
            Assert.LessOrEqual(-2.1 - t1.Y, Epsilon);
            Assert.LessOrEqual(1.55 - t1.Z, Epsilon);

            Assert.LessOrEqual(1.0 - t1.W, Epsilon);
        }

        [Test]
        //Use test cases to cover other variants
        public void Test_Length_GetLenghtOfAVector()
        {
            var t1 = new Tuple(1, 0, 0, 0.0);

            var length = t1.Length();

            Assert.LessOrEqual(1.0 - length, Epsilon);
        }

        [Test]
        public void Normalize_WhenCall_GetNormalizedVector()
        {
            var t1 = new Tuple(1, 2, 3, 0.0);
            var tNormalized = t1.Normalize();
            Assert.LessOrEqual(0.26726 - tNormalized.X, Epsilon);
            Assert.LessOrEqual(0.53452 - tNormalized.Y, Epsilon);
            Assert.LessOrEqual(0.80178 - tNormalized.Z, Epsilon);
        }

        [Test]
        public void Dot_WhenCall_GetANumber()
        {
            var a = Tuple.Vector(1, 2, 3);
            var b = Tuple.Vector(2, 3, 4);

            double result = Tuple.Dot(a, b);

            Assert.LessOrEqual(20 - result, Epsilon);
        }

        [Test]
        public void Cross_WhenCall_ReturnANewVector()
        {
            var a = Tuple.Vector(1, 2, 3);
            var b = Tuple.Vector(2, 3, 4);
            Tuple crossVector = Tuple.Cross(a, b);

            Assert.LessOrEqual(-1.0 - crossVector.X, Epsilon);
            Assert.LessOrEqual(2.0 - crossVector.Y, Epsilon);
            Assert.LessOrEqual(-1.0 - crossVector.Z, Epsilon);

            Assert.LessOrEqual(0.0 - crossVector.W, Epsilon);
        }
    }

}