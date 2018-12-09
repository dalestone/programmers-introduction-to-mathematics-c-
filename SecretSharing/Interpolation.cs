using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretSharing
{
    public class Interpolation
    {
        /// <summary>
        /// Return the unique degree n polynomial passing through the given n+1 points.
        /// </summary>
        public Polynomial Interpolate(List<int[]> points)
        {
            if (points.Count == 0)
                throw new ArgumentException("Must provide at least one point.");

            var xValues = points.Select(p => p[0]).ToList();

            if (new HashSet<int>(xValues).Count < points.Count)
                throw new ArgumentException("Not all x values are distinct.");

            Polynomial term = new Polynomial(new List<int> { 0 });

            foreach(var i in Enumerable.Range(0, points.Count))
            {
                term = SingleTerm(points, i);
            }

            return term.Add(new Polynomial(new List<int> { 0 }));
        }

        /// <summary>
        /// Return one term of an interpolated polynomial.
        /// </summary>
        public Polynomial SingleTerm(List<int[]> points, int i)
        {
            var term = new Polynomial(new List<int> { 1 });
            var xi = points[i][0];
            var yi = points[i][1];

            for(var j = 0; j < points.Count; j++)
            {
                var p = points[j];
                if (j == i)
                    continue;

                var xj = p[0];
                term = term.Multiply(new Polynomial(new List<int>
                {
                    -xj / (xi - xj),
                    1 / (xi - xj)
                }));
            }
                   
            return term.Multiply(new Polynomial(new List<int> { yi }));
        }
    }
}
