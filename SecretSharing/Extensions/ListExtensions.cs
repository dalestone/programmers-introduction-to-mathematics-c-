using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretSharing.Extensions
{
    public static class ListExtensions
    {
        public static List<int> StripEnd(this List<int> value, int stripVal)
        {
            if (value.Count == 0)
                return value;

            var i = value.Count - 1;

            while (i >= 0 && value[i] == stripVal)
                i -= 1;

            return value.Take(i + 1).ToList();
        }

        public static List<int> ZipLongest(this List<int> values, List<int> second, Func<int, int, int> resultSelector)
        {
            var diff = Math.Abs(values.Count - second.Count);

            if (values.Count > second.Count)
            {
                second.AddRange(Enumerable.Range(0, diff).Select(item => 0));
            }
            else
            {
                values.AddRange(Enumerable.Range(0, diff).Select(item => 0));
            }

            var newList = new List<int>();

            for (var i = 0; i < values.Count; i++)
            {
                newList.Add(resultSelector.Invoke(values[i], second[i]));
            }

            return newList;
        }
    }
}
