using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityTools.Runtime.UI
{
    [RequireComponent(typeof(ElementController))]
    public abstract class Element : UIBehaviour, IDisposable
    {
        [SerializeField]
        private bool _initializeOnStart;
        
        [SerializeField]
        private bool _hideOnStart;
        
        private ElementController _controller;

        private ElementController Controller {
            get {
                _controller ??= GetComponent<ElementController>();
                return _controller;
            }
        }

        protected override void Start()
        {
            if (_initializeOnStart) Initialize();
            if (_hideOnStart) Hide();
            else Show();
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

        public void Toggle()
        {
            Toggle(!Controller.IsVisible.Value);
        }
        
        public void Toggle(bool visible)
        {
            if (visible) Show();
            else Hide();
        }
        
        public virtual void Initialize() { }
        public virtual void Refresh() { }
        public virtual void ClearViews() { }

        protected virtual void OnShow() { }
        protected virtual void OnHide() { }
        
        public virtual void Dispose() { }
    }
}