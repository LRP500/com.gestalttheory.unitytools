using UnityEngine;

namespace UnityTools.Runtime
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField]
        private bool _dontDestroyOnLoad = true;
        
        private static T _current;
        
        public static T Current
        {
            get
            {
                if (_current != null) return _current;

                _current = FindObjectOfType<T>();

                if (_current != null) return _current;
                
                var obj = new GameObject(typeof(T).Name);
                _current = obj.AddComponent<T>();
                return _current;
            }
        }
        
        protected virtual void Awake()
        {
            if (_current != null && _current != this)
            {
                Destroy(gameObject);
                return;
            }

            _current = this as T;

            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            
            Initialize();
        }

        protected virtual void Initialize() { }
    }
}