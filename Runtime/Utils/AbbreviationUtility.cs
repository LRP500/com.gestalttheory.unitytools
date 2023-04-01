using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UnityTools.Runtime.Utilities
{
    public static class AbbreviationUtility
    {
        private static readonly SortedDictionary<long, string> _abbrevations = new()
        {
            { 1_000, "K" },
            { 1_000_000, "M" },
            { 1_000_000_000, "B" },
            { 1_000_000_000_000,"T" }
        };

        public static string Format(double number, string format = "0.00")
        {
            for (int i = _abbrevations.Count - 1; i >= 0; i--)
            {
                var (key, value) = _abbrevations.ElementAt(i);

                if (System.Math.Abs(number) >= key)
                {
                    return (number / key).ToString(format) + value;
                }
            }

            return number.ToString(CultureInfo.InvariantCulture);
        }

        public static string Format(float number, string format = "0.00")
        {
            return Format((double) number, format);
        }
        
        public static string Abbreviate(this long value, string format = "0.00")
        {
            return Format(value, format);
        }
    }
}
