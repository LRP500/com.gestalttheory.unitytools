using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;

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

        public static T Random<T>(this IList<T> list)
        {
            return list.IsNullOrEmpty() ? default : list[UnityEngine.Random.Range(0, list.Count)];
        }
        
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
            return list;
        }
    }
}