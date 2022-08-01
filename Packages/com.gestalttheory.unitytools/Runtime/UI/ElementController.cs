using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace UnityTools.Runtime.UI
{
    public sealed class ElementController : MonoBehaviour
    {
        private enum DisplayMode
        {
            Self,
            Canvas,
            CanvasGroup,
        }

        [SerializeField]
        private DisplayMode _displayMode;
        
        [SerializeField]
        [ShowIf("@ _displayMode == DisplayMode.Canvas")]
        private Canvas _canvas;

        [SerializeField]
        [ShowIf("@ _displayMode == DisplayMode.CanvasGroup")]
        private CanvasGroup _canvasGroup;

        private readonly BoolReactiveProperty _isVisible = new ();
        public IReadOnlyReactiveProperty<bool> IsVisible => _isVisible;

        private void SetVisible(bool visible)
        {
            if (_displayMode == DisplayMode.Self)
            {
                gameObject.SetActive(visible);
            }
            else if (_displayMode == DisplayMode.Canvas)
            {
                _canvas.enabled = visible;
            }
            else if (_displayMode == DisplayMode.CanvasGroup)
            {
                _canvasGroup.SetVisible(visible);
            }

            _isVisible.Value = visible;
        }

        public void Show()
        {
            SetVisible(true);
        }

        public void Hide()
        {
            SetVisible(false);
        }
    }
}