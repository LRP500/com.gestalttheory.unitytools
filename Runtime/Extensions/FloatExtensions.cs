﻿using UnityEngine;

namespace UnityTools.Runtime.Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.Float
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Return true if float is almost equal to value, return false otherwise. 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool AlmostEqual(this float self, float value, float tolerance)
        {
            return Mathf.Abs(self - value) < tolerance;
        }

        /// <summary>
        /// Return true if value is between min and max, return false otherwise
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <param name="include">include bounds</param>
        /// <returns></returns>
        public static bool InRange(this float self, float min, float max, bool include = true)
        {
            return include ? (self >= min && self <= max) : (self > min && self < max);
        }

        /// <summary>
        /// Remap value from range A to range B.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minA"></param>
        /// <param name="maxA"></param>
        /// <param name="minB"></param>
        /// <param name="maxB"></param>
        /// <returns></returns>
        public static float Remap(this float value, float minA, float maxA, float minB, float maxB)
        {
            float normal = Mathf.InverseLerp(minA, maxA, value);
            return Mathf.Lerp(minB, maxB, normal);
        }
    }
}