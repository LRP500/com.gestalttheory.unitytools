using System;
using UniRx;
using UnityEngine.SceneManagement;
using UnityTools.Runtime.Extensions;

namespace UnityTools.Runtime.Navigation
{
    public class NavigationManager : Singleton<NavigationManager>
    {
        public void LoadSceneAndSetActive(SceneReference scene, Action<float> onUpdate = null, Action onComplete = null)
        {
            LoadScene(scene, onUpdate, () =>
            {
                scene.SetActive();
                onComplete?.Invoke();
            });
        }

        private void LoadScene(SceneReference scene, Action<float> onUpdate = null, Action onComplete = null)
        {
            scene.LoadSceneAsync(LoadSceneMode.Additive)
                .ToObservable()
                .Do(x => onUpdate?.Invoke(x))
                .Last()
                .Subscribe(_ => onComplete?.Invoke())
                .AddTo(gameObject);
        }
    }
}