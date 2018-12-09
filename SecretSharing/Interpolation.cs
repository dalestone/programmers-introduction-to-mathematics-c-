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
        public void Interpolate(List<Point> points)
        {
            if (points.Count == 0)
                throw new ArgumentException("Must provide at least one point.");

            var xValues = points.Select(p => p.X).ToList();

            if (new HashSet<int>(xValues).Count < points.Count)
                throw new ArgumentException("Not all x values are distinct.");
        }

        /// <summary>
        /// Return one term of an interpolated polynomial.
        /// </summary>
        public void SingleTerm()
        {

        }
    }
}
