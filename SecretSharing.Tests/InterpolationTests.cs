using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SecretSharing.Tests
{
    public class InterpolationTests
    {
        [Fact]
        public void Test_Interpolate_Empty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Interpolation().Interpolate(new List<Point> { });
            });                       
        }

        [Fact]
        public void Test_Interpolate_Repeated_X_Values()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Interpolation().Interpolate(new List<Point>
                {
                    new Point(1, 2),
                    new Point(1, 3)
                });
            });            
        }

        [Fact]
        public void Test_Interpolate_Degree_0()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Test_Interpolate_Degree_1()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Test_Interpolate_Degree_3()
        {
            throw new NotImplementedException();
        }
    }
}
