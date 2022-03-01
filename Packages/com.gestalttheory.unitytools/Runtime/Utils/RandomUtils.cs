using UnityEngine;

namespace UnityTools.Runtime.Utils
{
    public static class RandomUtils
    {
        /// <summary>
        /// Returns a random value between 0 [inclusive] and 100 [inclusive].
        /// </summary>
        /// <returns></returns>
        public static int D100()
        {
            return Random.Range(0, 101);
        }
        
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static bool EvaluatePercentage(float percentage)
        {
            return Random.Range(0, 100) <= percentage;
        }
    }
}