using System;
using Xunit;
using Raytracer;

namespace XUnitTestRaytraceChallenge.UnitTests
{
    public class Color_Tests
    {
        [Fact]
        public void Color_ConstructorTest_AssignParameter2Properties()
        {
            var color = new Color(-0.5, 0.4, 1.7, 1.0);
            Assert.Equal(-0.5, color.R, 5);
            Assert.Equal(.4, color.G, 5);
            Assert.Equal(1.7, color.B, 5);
            Assert.Equal(1, color.A, 5);
        }

        [Fact]
        public void SumOperator_GetsTheSumOfTwoColors()
        {
            var c1 = new Color(0.5, 0, 1.0, 1.0);
            var c2 = new Color(0.5, 1, -1.0, 1.0);
            var c3 = c1 + c2;
            Assert.Equal(1, c3.R, 5);
            Assert.Equal(1, c3.G, 5);
            Assert.Equal(0, c3.B, 5);
            Assert.Equal(2, c3.A, 5);
        }

        [Fact]
        public void SubstracOperator_GetsTheSubstractOfTwoColors()
        {
            var c1 = new Color(0.5, 0, 1.0, 1.0);
            var c2 = new Color(0.5, 1, -1.0, 1.0);
            var c3 = c1 - c2;
            Assert.Equal(0, c3.R, 5);
            Assert.Equal(-1, c3.G, 5);
            Assert.Equal(2, c3.B, 5);
            Assert.Equal(0, c3.A, 5);
        }

        [Fact]
        public void MultiplyColorByScalar_GetaNewColorWithMultipliedValue()
        {
            var c = new Color(0.5, 0, 1.0, 0.0);

            var c1 = 2 * c;
            Assert.Equal(1, c1.R, 5);
            Assert.Equal(0, c1.G, 5);
            Assert.Equal(2, c1.B, 5);
            Assert.Equal(0, c1.A, 5);
        }

        [Fact]
        public void MultiplyColorByScalarCommutative_GetaNewColorWithMultipliedValue()
        {
            var c = new Color(0.5, 0, 1.0, 0.0);

            var c1 = c * 2;

            Assert.Equal(1, c1.R, 5);
            Assert.Equal(0, c1.G, 5);
            Assert.Equal(2, c1.B, 5);
            Assert.Equal(0, c1.A, 5);
        }
        [Fact]
        public void MultiplyColors_GetANewColor()
        {
            var c1 = new Color(0.5, 0, 1.0, 1.0);
            var c2 = new Color(0.5, 1, -1.0, 1.0);
            var c3 = c1 * c2;
            Assert.Equal(0.25, c3.R, 5);
            Assert.Equal(0, c3.G, 5);
            Assert.Equal(-1, c3.B, 5);
            Assert.Equal(1, c3.A, 5);
        }
    }
}
