using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityTools.Runtime.Lists;

namespace UnityTools.Runtime.Variables
{
    /// <summary>
    /// Register runtime component of type T to a ScriptableObject Reactive Variable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RegisterReactiveComponent<T> : MonoBehaviour where T : Object
    {
        [SerializeField]
        private RegisterMode _mode;
        
        [SerializeReference]
        [ShowIf("@ _mode == RegisterMode.Single")]
        private ReactiveVariable<T> _runtimeReference;

        [SerializeReference]
        [ShowIf("@ _mode == RegisterMode.List")]
        private ReactiveListVariable<T> _runtimeList;
        
        [SerializeField]
        private bool _clearOnDestroy;
        
        private T _component;
        
        private void Awake()
        {
            if (_clearOnDestroy)
            {
                this.OnDestroyAsObservable()
                    .Subscribe(_ => Unregister());
            }
            
            Register();
        }

        private void Register()
        {
            _component = GetComponent();
            
            if (_mode == RegisterMode.Single)
            {
                _runtimeReference.SetValue(_component);
            }
            else if (_mode == RegisterMode.List)
            {
                _runtimeList.Add(_component);
            }
        }
        
        private void Unregister()
        {
            if (_mode == RegisterMode.Single)
            {
                _runtimeReference.Clear();
            }
            else if (_mode == RegisterMode.List)
            {
                _runtimeList.Remove(_component);
            }
        }
        
        protected virtual T GetComponent()
        {
            return GetComponent<T>();
        }
    }
}