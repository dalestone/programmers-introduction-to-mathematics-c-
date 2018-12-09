using SecretSharing.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretSharing
{
    /// <summary>
    /// A class representing a polynomial as a list of coefficients with no 
    /// trailing zeros.
    /// A degree zero polynomial corresponds to the empty list of coefficients.   
    /// </summary>
    public class Polynomial
    {
        public List<int> Coefficients { get; }
        private string Indeterminate { get; set; }

        /// <summary>
        /// Create a new polynomial.
        /// The caller must provide a list of all coefficients of the
        /// polynomial, even those that are zero.E.g.,
        /// Polynomial([0, 1, 0, 2]) corresponds to f(x) = x + 2x^3.        
        /// </summary>
        /// <param name="coefficients"></param>
        /// <param name="indeterminate"></param>
        public Polynomial(List<int> coefficients, string indeterminate = "x")
        {
            Coefficients = coefficients.StripEnd(0);
            Indeterminate = indeterminate;
        }

        public Polynomial Add(Polynomial polynomial)
        {
            var newCoefficients = Coefficients.ZipLongest(polynomial.Coefficients, (co1, co2) => co1 + co2).ToList();
           
            return new Polynomial(newCoefficients);
        }

        public Polynomial Subtract(Polynomial polynomial)
        {
            var newCoefficients = Coefficients.ZipLongest(polynomial.Coefficients, (co1, co2) => co1 - co2).ToList();

            return new Polynomial(newCoefficients);
        }

        public Polynomial Multiply(Polynomial polynomial)
        {
            List<int> newCoeffs = Enumerable.Range(0, Coefficients.Count + polynomial.Coefficients.Count - 1)
                                .Select(c => 0)
                                .ToList();

            for (var i = 0; i < Coefficients.Count; i++)
            {
                var a = Coefficients[i];

                for (var j = 0; j < polynomial.Coefficients.Count; j++)
                {
                    var b = polynomial.Coefficients[j];

                    newCoeffs[i + j] += a * b;
                }
            }

            return new Polynomial(newCoeffs.StripEnd(0));
        }

        public Polynomial Negate()
        {
            return new Polynomial(Coefficients.Select(c => -1 * c).ToList());
        }

        /// <summary>
        /// Evaluate a polynomial at an input point.     
        /// Uses Horner's method, first discovered by Persian mathematician
        /// Sharaf al-Dīn al-Ṭūsī, which evaluates a polynomial by minimizing
        /// the number of multiplications.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int EvaluateAt(int x)
        {
            var sum = 0;

            foreach (var c in Coefficients.AsEnumerable().Reverse())
            {
                sum = sum * x + c;
            }

            return sum;
        }
       
        public override string ToString()
        {
            var expr = "";

            for (var i = 0; i < Coefficients.Count; i++)
            {
                if (i > 0)
                {
                    expr += $"{Coefficients[i]} x^{i}";

                    if (i + 1 != Coefficients.Count)
                    {
                        expr += " + ";
                    }
                }
                else
                {
                    expr += $"{Coefficients[i]} + ";
                }
            }

            return expr;
        }
    }
}