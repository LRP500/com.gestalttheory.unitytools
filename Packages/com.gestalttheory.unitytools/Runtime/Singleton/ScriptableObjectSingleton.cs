using UnityEngine;

namespace UnityTools.Runtime
{
    /// <summary>
    /// A ScriptableObject singleton for use at runtime.
    /// </summary>
    /// <remarks>The asset should have the same name as the class in order for it to work.</remarks>
    public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObjectSingleton<T>
    {
        private static readonly string AssetPath = typeof(T).Name;
        
        private static T _instance;

        public static T Instance => _instance != null ? _instance : FindInstance(); 

        private static T FindInstance()
        {
            if (_instance != null) return _instance;
                
            var results = Resources.FindObjectsOfTypeAll<T>();

            if (results.Length == 0)
            {
                _instance = Resources.Load<T>(AssetPath);
                if (_instance != null) return _instance;
                Debug.LogError($"Multiple instances of scriptable object singleton of type ({typeof(T).Name})");
                throw new MissingReferenceException(typeof(T).Name);
            }

            if (results.Length > 1)
            {
                Debug.LogError($"Multiple instances of scriptable object singleton of type ({typeof(T).Name})");
            }

            _instance = results[0];
            _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;

            return _instance;
        }
        
        protected virtual void Awake()
        {
            _instance = (T) this;
            _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
        
        // Called when the singleton is destroyed after exiting play mode.
        protected virtual void OnDestroy() => _instance = null;
        
        // Called when the singleton is created *or* after a domain reload in the editor.
        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#endif
        }

#if UNITY_EDITOR
        private static void OnPlayModeStateChanged( UnityEditor.PlayModeStateChange stateChange )
        {
            if (stateChange != UnityEditor.PlayModeStateChange.EnteredEditMode) return;
            UnityEditor.EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            _instance = null;
        }
#endif
    }
}