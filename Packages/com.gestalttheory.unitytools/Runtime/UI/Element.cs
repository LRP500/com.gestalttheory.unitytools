using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace UnityTools.Runtime.UI
{
    public abstract class Element<T> : MonoBehaviour where T : ElementController
    {
        public T Controller { get; private set; }

        #region IUpdatable

        private void Awake()
        {
            Controller = GetComponent<T>();
            Controller.OnInitialize.Subscribe(_ => OnInitialize()).AddTo(this);
            Controller.OnRefresh.Subscribe(_ => OnRefresh()).AddTo(this);
            Controller.OnVisibilityChanged.WhereTrue().Subscribe(_ => OnOpen()).AddTo(this);
            Controller.OnVisibilityChanged.WhereFalse().Subscribe(_ => OnClose()).AddTo(this);
        }

        protected virtual void OnInitialize() { }
        protected virtual void OnRefresh() { }
        protected virtual void OnClear() { }
        protected virtual void OnOpen() { }
        protected virtual void OnClose() { }
        
        #endregion IUpdatable
    }
}