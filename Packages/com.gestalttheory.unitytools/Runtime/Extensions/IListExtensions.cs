using System;
using System.Collections.Generic;

namespace UnityTools.Runtime.Extensions
{
    public static class IListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)  
        {  
            int n = list.Count;
            var rng = new Random();  

            while (n > 1)
            {
                n--;  
                int k = rng.Next(n + 1);  
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}