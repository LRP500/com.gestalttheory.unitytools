using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.ECA.Actions;

namespace UnityTools.Runtime.Form
{
    public abstract class FormController<T> : MonoBehaviour, IDisposable where T : FormData
    {
        public readonly ISubject<bool> OnSubmit = new Subject<bool>();
        public readonly ISubject<Unit> OnRefresh = new Subject<Unit>();

        [SerializeField]
        private Button _submitButton;

        [SerializeField]
        private ScriptableAction<T> _submitAction;

        public T Data { get; private set; }
        protected CompositeDisposable Disposable { get; private set; } = new ();
        
        public virtual void Initialize()
        {
            Data = CreateForm();
            Disposable = new CompositeDisposable();
            RegisterCallbacks();
            Refresh();
        }

        protected virtual void RegisterCallbacks()
        {
            _submitButton.onClick
                .AsObservable()
                .Subscribe(_ => Submit())
                .AddTo(Disposable);
        }

        private void RefreshActions()
        {
            var dataValid = Data.IsValid();
            _submitButton.interactable = dataValid;
        }
        
        protected virtual void Refresh()
        {
            RefreshActions();
            OnRefresh.OnNext(Unit.Default);
        }
   
        protected void AddField(IFormField field)
        {
            field.Target.OnSelectAsObservable()
                .Subscribe(_ => Refresh())
                .AddTo(Disposable);
        }
        
        private void Submit()
        {
            var success = _submitAction.Execute(Data);
            OnSubmit.OnNext(success);
        }
        
        public virtual void Dispose()
        {
            Disposable?.Dispose();
        }

        protected abstract T CreateForm();
    }
}
