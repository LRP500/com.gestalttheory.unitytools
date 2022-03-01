using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityTools.Runtime.ECA.Actions;
using UnityTools.Runtime.ECA.Conditions;

namespace UnityTools.Runtime.ECA.Events
{
    public class ScriptableEventListener : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEvent _event;
        
        [SerializeField]
        private UnityEvent _response;

        [SerializeField]
        private List<ScriptableCondition> _conditions;

        [SerializeField]
        private List<ScriptableAction> _actions;

        private void OnEnable()
        {
            _event.RegisterListener(this);
        }

        private void OnDisable()
        {
            _event.UnregisterListener(this);
        }

        public void RaiseEvent()
        {
            if (CheckConditions())
            {
                ExecuteActions();
            }
        }

        private bool CheckConditions()
        {
            for (int i = 0, length = _conditions.Count; i < length; ++i)
            {
                if (!_conditions[i].Check())
                {
                    return false;
                }
            }

            return true;
        }

        private void ExecuteActions()
        {
            _response.Invoke();
            
            for (int i = 0, length = _actions.Count; i < length; ++i)
            {
                _actions[i].Execute();
            }
        }
    }
}
