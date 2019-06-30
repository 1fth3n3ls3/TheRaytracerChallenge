using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Raytracer;

namespace XUnitTestRaytraceChallenge.UnitTests
{
    public class Canvas_Tests
    {
        [Fact]
        public void Canvas_WhenCreated_GetAFrameWithAGivenHeightAndWidth()
        {
            var canvas = new Canvas(100, 200);
            Assert.Equal(200, canvas.Height);
            Assert.Equal(100, canvas.Width);
            for (int i = 0; i < canvas.Pixels.GetLength(0); i++)
                for (int j = 0; j < canvas.Pixels.GetLength(1); j++)
                    Assert.Equal(new Color(0,0,0,1), canvas.Pixels[i, j].Color);
        }

        [Fact]
        public void Pixel_WhenCreated_GetABlackColorAssigned()
        {
            var pixel = new Pixel();
            Assert.Equal(new Color(0, 0, 0, 1), pixel.Color);
        }
    }
}
