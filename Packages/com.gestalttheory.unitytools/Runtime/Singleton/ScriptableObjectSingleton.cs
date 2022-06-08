using UnityEngine;

namespace UnityTools.Runtime
{
    public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        private static T _current;

        public static T Current
        {
            get
            {
                if (_current != null)
                {
                    return _current;
                }
                
                var results = Resources.FindObjectsOfTypeAll<T>();

                if (results.Length == 0)
                {
                    Debug.LogError($"Missing instance of scriptable object singleton of type {typeof(T).Name}");
                    return null;
                }

                if (results.Length > 1)
                {
                    Debug.LogError($"Multiple instances of scriptable object singleton of type ({typeof(T).Name})");
                    return null;
                }

                _current = results[0];
                _current.hideFlags = HideFlags.DontUnloadUnusedAsset;

                return _current;
            }
        }
    }
}