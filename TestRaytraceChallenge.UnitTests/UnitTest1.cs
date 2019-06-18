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
            Assert.That(tuple.x == 4.3);
            Assert.That(tuple.y == -4.2);
            Assert.That(tuple.z == 3.1);
            Assert.That(tuple.w == 0.0);
            Assert.True(tuple.IsVector());
            Assert.False(tuple.IsPoint());

        }

        [Test]
        public void Test_IsPoint_GivenATuppleFindOutIsPoint()
        {
            ITuple tuple = new Tuple (4.3, -4.2, 3.1, 1.0);
            Assert.That(tuple.x == 4.3);
            Assert.That(tuple.y == -4.2);
            Assert.That(tuple.z == 3.1);
            Assert.That(tuple.w == 1.0);
            Assert.LessOrEqual(1.0 - tuple.w, Epsilon);
            Assert.True(tuple.IsPoint());
            Assert.False(tuple.IsVector());

        }

        [Test]
        public void Test_Vector_CheckTupleIsBuildedJustRight()
        {
            ITuple tuple = Tuple.Vector(4.3, -4.2, 3.1);
            Assert.That(tuple.x == 4.3);
            Assert.That(tuple.y == -4.2);
            Assert.That(tuple.z == 3.1);
            Assert.That(tuple.w == 0.0);

        }

        [Test]
        public void Test_Point_CheckTupleIsBuildedJustRight()
        {
            ITuple tuple = Tuple.Point(4.3, -4.2, 3.1);
            Assert.That(tuple.x == 4.3);
            Assert.That(tuple.y == -4.2);
            Assert.That(tuple.z == 3.1);
            Assert.That(tuple.w == 1.0);

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

            Assert.LessOrEqual(0.0 - t1.x, Epsilon);
            Assert.LessOrEqual(0.0 - t1.y, Epsilon);
            Assert.LessOrEqual(0.0 - t1.z, Epsilon);

            Assert.LessOrEqual(1.0 - t1.w, Epsilon);
        }

        [Test]
        public void Test_Add_SumAVectorAndAVector()
        {
            var t1 = Tuple.Vector(4.3, -4.2, 3.1);
            var t2 = Tuple.Vector(-4.3, 4.2, -3.1);

            var result = t1.Add(t2);

            Assert.LessOrEqual(0.0 - t1.x, Epsilon);
            Assert.LessOrEqual(0.0 - t1.y, Epsilon);
            Assert.LessOrEqual(0.0 - t1.z, Epsilon);

            Assert.LessOrEqual(0.0 - t1.w, Epsilon);
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
            t1 = -t1;
            Assert.LessOrEqual(-4.3 - t1.x, Epsilon);
            Assert.LessOrEqual(4.2 - t1.y, Epsilon);
            Assert.LessOrEqual(-3.1 - t1.z, Epsilon);

            Assert.LessOrEqual(1.0 - t1.w, Epsilon);
        }

        [Test]
        public void Test_ScalarMultiplication_GetDoubleLongituded()
        {
            var t1 = new Tuple(4.3, -4.2, 3.1, 1.0);
            t1 = 2 * t1;
            Assert.LessOrEqual(8.6 - t1.x, Epsilon);
            Assert.LessOrEqual(-8.4 - t1.y, Epsilon);
            Assert.LessOrEqual(6.2 - t1.z, Epsilon);

            Assert.LessOrEqual(1.0 - t1.w, Epsilon);
        }

        [Test]
        public void Test_ScalarDivision_GetHalfLongituded()
        {
            var t1 = new Tuple(4.3, -4.2, 3.1, 1.0);
            t1 = t1 / 2;
            Assert.LessOrEqual(2.15 - t1.x, Epsilon);
            Assert.LessOrEqual(-2.1 - t1.y, Epsilon);
            Assert.LessOrEqual(1.55 - t1.z, Epsilon);

            Assert.LessOrEqual(1.0 - t1.w, Epsilon);
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
        public void Test_Normalize_GetNormalizedVector()
        {
            var t1 = new Tuple(1, 2, 3, 0.0);
            var tNormalized = t1.Normalize();
            Assert.LessOrEqual(0.26726 - tNormalized.x, Epsilon);
            Assert.LessOrEqual(0.53452 - tNormalized.y, Epsilon);
            Assert.LessOrEqual(0.80178 - tNormalized.z, Epsilon);

        }
    }

}