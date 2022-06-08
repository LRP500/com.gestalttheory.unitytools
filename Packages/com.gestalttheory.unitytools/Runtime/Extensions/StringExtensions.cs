using System.Text.RegularExpressions;

namespace UnityTools.Runtime.Extensions
{
    public static class StringExtensions
    {
        public static string Humanize(this string source)
        {
            string returnValue = source;
            returnValue = Regex.Replace(returnValue, "^_", "").Trim(); 
            returnValue = Regex.Replace(returnValue, "([a-z])([A-Z])", "$1 $2").Trim(); 
            returnValue = Regex.Replace(returnValue, "([A-Z])([A-Z][a-z])", "$1 $2").Trim(); 
            return returnValue;
        }
    }
}