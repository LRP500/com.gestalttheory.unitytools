using UnityEngine;

namespace UnityTools.Runtime.Variables.Registerers
{
    public class RegisterGameObject : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable _variable;

        private void Awake()
        {
            _variable.SetValue(gameObject);
        }
    }
}