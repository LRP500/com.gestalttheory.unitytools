using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.UI
{
    public abstract class ElementController : MonoBehaviour, IHideable
    {
        public readonly ISubject<Unit> OnRefresh = new Subject<Unit>();

        public virtual void Refresh()
        {
            OnRefresh.OnNext(Unit.Default);
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
            SetVisible(true);
            Refresh();
        }

        public void Hide()
        {
            SetVisible(false);
            Clear();
        }

        #endregion IHideable
    }
}