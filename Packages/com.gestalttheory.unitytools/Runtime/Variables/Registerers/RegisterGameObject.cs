using UnityEngine;

namespace UnityTools.Runtime.Variables.Registerers
{
    public class RegisterGameObject : RegisterComponent<GameObject>
    {
        protected override GameObject GetComponent() => gameObject;
    }
}