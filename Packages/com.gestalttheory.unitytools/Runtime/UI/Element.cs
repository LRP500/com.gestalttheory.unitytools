using System;
using UnityEngine;

namespace UnityTools.Runtime.UI
{
    [RequireComponent(typeof(ElementController))]
    public abstract class Element : MonoBehaviour, IDisposable
    {
        [SerializeField]
        private bool _initializeOnAwake;
        
        private ElementController _controller;

        private ElementController Controller {
            get {
                _controller ??= GetComponent<ElementController>();
                return _controller;
            }
        }

        private void Awake()
        {
            if (_initializeOnAwake)
            {
                Initialize();
            }
        }

        public void Show()
        {
            Controller.Show();
            OnShow();
        }

        public void Hide()
        {
            Controller.Hide();
            Dispose();
            OnHide();
        }

        public void Toggle(bool visible)
        {
            if (visible) Show();
            else Hide();
        }
        
        public virtual void Initialize() { }
        public virtual void Refresh() { }
        public virtual void Clear() { }

        protected virtual void OnShow() { }
        protected virtual void OnHide() { }
        
        public virtual void Dispose() { }
    }
}