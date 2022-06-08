using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTools.Runtime.Navigation
{
    /// <summary>
    /// Class used to serialize a reference to a scene asset that can be used
    /// at runtime in a build, when the asset can no longer be directly
    /// referenced. This caches the scene name based on the SceneAsset to use
    /// at runtime to load.
    /// https://github.com/roboryantron/UnityEditorJunkie/tree/master/Assets/SceneReference
    /// </summary>
    [Serializable]
    public class SceneReference : ISerializationCallbackReceiver
    {
        /// <summary>
        /// Exception that is raised when there is an issue resolving and
        /// loading a scene reference.
        /// </summary>
        public class SceneLoadException : Exception
        {
            public SceneLoadException(string message) : base(message)
            {}
        }
        
#if UNITY_EDITOR
        public UnityEditor.SceneAsset scene;
#endif

        [Tooltip("The name of the referenced scene. This may be used at runtime to load the scene.")]
        public string sceneName;

        [SerializeField]
        private int _sceneIndex = -1;

        [SerializeField]
        private bool _sceneEnabled;

        public bool IsLoaded => SceneManager.GetSceneByName(sceneName).isLoaded;
        
        private void ValidateScene()
        {
            if (string.IsNullOrEmpty(sceneName))
                throw new SceneLoadException("No scene specified.");
            
            if (_sceneIndex < 0)
                throw new SceneLoadException($"Scene {sceneName} is not in the build settings");
            
            if (!_sceneEnabled)
                throw new SceneLoadException($"Scene {sceneName} is not enabled in the build settings");
        }
        
        public void LoadScene(LoadSceneMode mode = LoadSceneMode.Single)
        {
            ValidateScene();
            SceneManager.LoadScene(sceneName, mode);
        }

        public AsyncOperation LoadSceneAsync(LoadSceneMode mode = LoadSceneMode.Single)
        {
            ValidateScene();
            return SceneManager.LoadSceneAsync(sceneName, mode);
        }

        public bool SetActive()
        {
            var sceneToActivate = SceneManager.GetSceneByName(sceneName);
            return SceneManager.SetActiveScene(sceneToActivate);
        }
        
        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (scene == null)
            {
                sceneName = string.Empty;
                return;
            }
            
            string sceneAssetPath = UnityEditor.AssetDatabase.GetAssetPath(scene);
            string sceneAssetGUID = UnityEditor.AssetDatabase.AssetPathToGUID(sceneAssetPath);
            var scenes = UnityEditor.EditorBuildSettings.scenes;

            _sceneIndex = -1;
            for (int i = 0; i < scenes.Length; i++)
            {
                if (scenes[i].guid.ToString() != sceneAssetGUID)
                    continue;
                
                _sceneIndex = i;
                _sceneEnabled = scenes[i].enabled;
                
                if (scenes[i].enabled)
                    sceneName = scene.name;
                
                break;
            }
#endif
        }

        public void OnAfterDeserialize() {}
    }
}