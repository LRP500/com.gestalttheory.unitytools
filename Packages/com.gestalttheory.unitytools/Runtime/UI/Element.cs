using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.UI
{
    public abstract class Element<T> : MonoBehaviour where T : ElementController
    {
        public T Controller { get; private set; }

        #region IUpdatable

        public virtual void Initialize()
        {
            Controller = GetComponent<T>();
            Controller.OnRefresh.Subscribe(_ => Refresh());
        }
        
        protected virtual void Refresh() { }
        protected virtual void Clear() { }
        
        #endregion IUpdatable
    }
}