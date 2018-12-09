using System;
using System.Collections.Generic;
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
                throw new ArgumentException("Must provide at least one point");


        }

        /// <summary>
        /// Return one term of an interpolated polynomial.
        /// </summary>
        public void SingleTerm()
        {

        }
    }
}
