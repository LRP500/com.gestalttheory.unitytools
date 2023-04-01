using UnityEngine;

namespace UnityTools.Runtime.ECA.Events
{
    public class ScriptableEventTrigger : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEvent _event;

        public void Trigger()
        {
            _event.Raise();
        }
    }
}