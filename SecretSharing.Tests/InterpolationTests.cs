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
                new Interpolation().Interpolate(new List<int[]> { });
            });                       
        }

        [Fact]
        public void Test_Interpolate_Repeated_X_Values()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Interpolation().Interpolate(new List<int[]>
                {
                    new int[]{ 1, 2 },
                    new int[]{ 1, 3 }
                });
            });            
        }

        [Fact]
        public void Test_Interpolate_Degree_0()
        {
            var expected = new List<int> { 2 };
            var actual = new Interpolation().Interpolate(new List<int[]>
            {
                new int[] { 1, 2 }
            }).Coefficients;

            Assert.Equal(expected, actual);            
        }

        [Fact]
        public void Test_Interpolate_Degree_1()
        {
            var expected = new List<int> { 1, 1 };
            var actual = new Interpolation().Interpolate(new List<int[]>
            {
                new int[] { 1, 2 },
                new int[] { 2, 3 }
            }).Coefficients;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Interpolate_Degree_3()
        {
            throw new NotImplementedException();
        }
    }
}
