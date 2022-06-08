using DG.Tweening;
using UnityEngine;

namespace UnityTools.Runtime.Navigation
{
    public class SceneFader : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [Min(0)]
        [SerializeField]
        private float _duration = 1;
        
        private Tween _fadeTween;
        
        public void FadeOut(TweenCallback onComplete)
        {
            _fadeTween?.Kill();
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = true;
            _fadeTween = _canvasGroup.DOFade(1, _duration);
            _fadeTween.onComplete += onComplete;
        }
    }
}