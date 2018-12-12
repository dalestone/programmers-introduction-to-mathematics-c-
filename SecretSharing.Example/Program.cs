using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretSharing.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new Polynomial(new List<int> { 109, -55, 271 });

            foreach (var i in Enumerable.Range(1, 5))
                Console.WriteLine($"({i}, {f.EvaluateAt(i)})");

            var pts = new List<int[]> {
                new int[] { 1, 325 },
                new int[] { 3, 2383 },
                new int[] { 5, 6609 }
            };
            f = new Interpolation().Interpolate(pts);

            Console.WriteLine(f);
            Console.WriteLine(f.EvaluateAt(0));

            //pts = new List<int[]>
            //{
            //    new int[] { 2, 1083 },
            //    new int[] { 5, 6609 }
            //};
            //pts.Add(new int[] { 0, 533 });
            //f = new Interpolation().Interpolate(pts);

            //Console.WriteLine(f);
            //Console.WriteLine(f.EvaluateAt(0));

            Console.ReadKey(true);
        }
    }
}
