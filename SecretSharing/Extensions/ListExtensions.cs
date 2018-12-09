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

        public static List<int> ZipLongest(this List<int> first, List<int> second, Func<int, int, int> resultSelector)
        {
            var newList = new List<int>();
            var diff = Math.Abs(first.Count - second.Count);
            var placeholders = Enumerable.Range(0, diff).Select(item => 0);

            if (first.Count > second.Count)
                second.AddRange(placeholders);
            else
                first.AddRange(placeholders);

            for (var i = 0; i < first.Count; i++)
                newList.Add(resultSelector.Invoke(first[i], second[i]));

            return newList;
        }
    }
}
