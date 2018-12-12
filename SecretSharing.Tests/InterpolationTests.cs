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
            var points = new List<int[]> {
                new int[] { 1, 1 },
                new int[] { 2, 0 },
                new int[] { -3, 2 },
                new int[] { 4, 4 }
            };
            var actualPolynomial = new Interpolation().Interpolate(points);
            var expectedEvaluations = points;
            var actualEvaluations = new List<int>();

            foreach(var item in expectedEvaluations)
            {
                actualEvaluations.Add(actualPolynomial.EvaluateAt(item[0]));
            }
                
            //points = [(1, 1), (2, 0), (-3, 2), (4, 4)]
            //actual_polynomial = interpolate(points)
            //expected_evaluations = points
            //actual_evaluations = [(x, actual_polynomial.evaluateAt(x))
            //                      for (x, y) in expected_evaluations]

            //for (p1, p2) in zip(expected_evaluations, actual_evaluations):
            //    for (a, b) in zip(p1, p2):
            //        assert_that(a).is_close_to(b, EPSILON)
        }
    }
}
