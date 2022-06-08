using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace Variables.Registerers
{
    public class RegisterCamera : MonoBehaviour
    {
        [SerializeField]
        private CameraVariable _runtimeReference;

        [SerializeField]
        private bool _clearOnDestroy;
        
        private Camera _component;
        
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
            _component = GetComponent<Camera>();
            _runtimeReference.SetValue(_component);
        }
        
        private void Unregister()
        {
            _runtimeReference.Clear();
        }
    }
}