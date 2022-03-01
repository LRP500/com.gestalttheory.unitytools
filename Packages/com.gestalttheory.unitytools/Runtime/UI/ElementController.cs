using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.UI
{
    public abstract class ElementController : MonoBehaviour, IHideable
    {
        public readonly ISubject<Unit> OnInitialize = new Subject<Unit>();
        public readonly ISubject<Unit> OnRefresh = new Subject<Unit>();
        public readonly ISubject<bool> OnVisibilityChanged = new Subject<bool>();

        [SerializeField]
        private List<ElementController> _children;

        [SerializeField]
        private bool _initializeOnAwake;

        private void Awake()
        {
            if (_initializeOnAwake)
            {
                Initialize();
            }
        }

        public virtual void Initialize()
        {
            InitializeChildren();
            OnInitialize.OnNext(Unit.Default);
        }
        
        public virtual void Refresh()
        {
            RefreshChildren();
            OnRefresh.OnNext(Unit.Default);
        }
        
        private void InitializeChildren()
        {
            for (int i = 0, length = _children.Count; i < length; ++i)
            {
                _children[i].Initialize();
            }
        }

        private void RefreshChildren()
        {
            for (int i = 0, length = _children.Count; i < length; ++i)
            {
                _children[i].Refresh();
            }
        }

        protected virtual void Clear() { }
        
        #region IHideable

        protected abstract void SetVisible(bool visible);

        public void Toggle(bool opened)
        {
            if (opened) Show();
            else Hide();
        }

        public void Show()
        {
            OnVisibilityChanged.OnNext(true);
            SetVisible(true);
            Refresh();
        }

        public void Hide()
        {
            OnVisibilityChanged.OnNext(false);
            SetVisible(false);
            Clear();
        }

        #endregion IHideable
    }
}