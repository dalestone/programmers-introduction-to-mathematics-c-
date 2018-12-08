using System.Collections.Generic;
using System.Linq;

namespace Polynomial
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
    }
}
