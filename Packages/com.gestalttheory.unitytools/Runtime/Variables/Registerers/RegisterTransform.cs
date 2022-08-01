using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityTools.Runtime.Lists;

namespace UnityTools.Runtime.Variables.Registerers
{
    public class RegisterTransform : MonoBehaviour
    {
        [SerializeField]
        private RegisterMode _mode;
        
        [SerializeReference]
        [ShowIf("@ _mode == RegisterMode.Single")]
        private TransformVariable _runtimeReference;

        [SerializeReference]
        [ShowIf("@ _mode == RegisterMode.List")]
        private TransformListVariable _runtimeList;
        
        [SerializeField]
        private bool _clearOnDestroy = true;
        
        private Transform _component;
        
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
            _component = transform;
            
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
    }
}