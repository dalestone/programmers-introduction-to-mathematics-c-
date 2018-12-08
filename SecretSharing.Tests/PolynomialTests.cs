using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SecretSharing.Tests
{
    public class PolynomialTests
    {
        [Fact]
        public void Test_Polynomial_Zero()
        {
            var expected = new int[] { };
            var actual = new Polynomial(new List<int> { 0 }).Coefficients;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Polynomial_Repr()
        {
            var expected = "1 + 2 x^1 + 3 x^2";  
            var actual = new Polynomial(new List<int> { 1, 2, 3 }).ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Polynomial_Add()
        {
            var f = new Polynomial(new List<int> { 1, 2, 3 });
            var g = new Polynomial(new List<int> { 4, 5, 6 });

            var expected = new List<int> { 5, 7, 9 };
            var actual = f.Add(g).Coefficients; 
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Polynomial_Sub()
        {
            var f = new Polynomial(new List<int> { 1, 2, 3 });
            var g = new Polynomial(new List<int> { 4, 5, 6 });
      
            var expected = new List<int> { -3, -3, -3 };
            var actual = f.Subtract(g).Coefficients;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Polynomial_Add_Zero()
        {
            var f = new Polynomial(new List<int> { 1, 2, 3 });
            var g = new Polynomial(new List<int> { 0 });

            var expected = new List<int> { 1, 2, 3 };
            var actual = f.Add(g).Coefficients;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Polynomial_Multiply()
        {
            var f = new Polynomial(new List<int> { 1, 2, 3 });
            var g = new Polynomial(new List<int> { 4, 5, 6 });

            var expected = new List<int> { 4, 13, 28, 27, 18 };
            var actual = f.Multiply(g).Coefficients;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Polynomial_Negate()
        {
            var expected = new List<int> { -1, -2, -3 };
            var actual = new Polynomial(new List<int> { 1, 2, 3 }).Negate();

            Assert.Equal(expected, actual.Coefficients);
        }

        [Fact]
        public void Test_Polynomial_Evaluate_At()
        {            
            var f = new Polynomial(new List<int> { 1, 2, 3 });

            var expected = 1 + 4 + 12;
            var actual = f.EvaluateAt(2);

            Assert.Equal(expected, actual);                   
        }
    }
}





