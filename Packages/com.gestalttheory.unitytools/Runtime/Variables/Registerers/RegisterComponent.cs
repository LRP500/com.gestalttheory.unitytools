using Sirenix.OdinInspector;
using UnityEngine;
using UnityTools.Runtime.Lists;

namespace UnityTools.Runtime.Variables
{
    /// <summary>
    /// Register runtime component of type T to a ScriptableObject Variable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RegisterComponent<T> : MonoBehaviour where T : Object
    {
        [SerializeField]
        private RegisterMode _mode;
        
        [SerializeReference]
        [ShowIf("@ _mode == RegisterMode.Single")]
        private Variable<T> _runtimeReference;

        [SerializeReference]
        [ShowIf("@ _mode == RegisterMode.List")]
        private ListVariable<T> _runtimeList;
        
        private void Awake()
        {
            if (_mode == RegisterMode.Single)
            {
                _runtimeReference.SetValue(GetComponent<T>());
            }
            else if (_mode == RegisterMode.List)
            {
                _runtimeList.Add(GetComponent<T>());
            }
        }
    }
}