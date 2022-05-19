using UnityEngine;

namespace UnityTools.Runtime
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _current;
        
        public static T Current
        {
            get
            {
                _current ??= FindObjectOfType<T>();
                
                if (_current != null)
                    return _current;
                
                var obj = new GameObject(typeof(T).Name);
                _current = obj.AddComponent<T>();
                return _current;
            }
        }
    }
}