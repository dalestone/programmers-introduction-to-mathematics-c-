using System.Linq;

namespace Polynomial
{
    public static class StringExtensions
    {
        public static string StripEnd(this string value, char stripVal)
        {
            if (value.Length == 0)
                return value;

            var i = value.Length - 1;

            while (i >= 0 && value[i] == stripVal)
                i -= 1;

            return new string(value.Take(i + 1).ToArray());
        }
    }
}
