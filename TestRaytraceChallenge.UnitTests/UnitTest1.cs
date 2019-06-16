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
    }

}