using UnityEngine;

namespace Tools.Variables.Components
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