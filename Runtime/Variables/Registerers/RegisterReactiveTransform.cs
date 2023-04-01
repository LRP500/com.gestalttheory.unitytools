using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityTools.Runtime.Lists;

namespace UnityTools.Runtime.Variables.Registerers
{
    [ExecuteInEditMode]
    public class RegisterReactiveTransform : MonoBehaviour
    {
        [SerializeField]
        private RegisterMode _mode;
        
        [SerializeReference]
        [ShowIf("@ _mode == RegisterMode.Single")]
        private ReactiveVariable<Transform> _runtimeReference;

        [SerializeReference]
        [ShowIf("@ _mode == RegisterMode.List")]
        private ReactiveListVariable<Transform> _runtimeList;
        
        [SerializeField]
        private bool _clearOnDestroy;
        
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
            if (_mode == RegisterMode.Single)
            {
                _runtimeReference.SetValue(transform);
            }
            else if (_mode == RegisterMode.List)
            {
                _runtimeList.Values.Add(transform);
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
                _runtimeList.Values.Remove(transform);
            }
        }
    }
}