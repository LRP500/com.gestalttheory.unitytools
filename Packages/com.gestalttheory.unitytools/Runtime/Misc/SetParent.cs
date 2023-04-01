using UnityEngine;

namespace UnityTools.Runtime.Variables.Misc
{
    public class SetParent : MonoBehaviour
    {
        [SerializeField]
        private TransformVariable _parent;

        [SerializeField]
        private bool _worldPositionStays = true;
        
        private void Start()
        {
            transform.SetParent(_parent.Value, _worldPositionStays);
        }
    }
}