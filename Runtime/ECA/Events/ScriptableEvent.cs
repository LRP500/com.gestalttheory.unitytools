using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityTools.Runtime.ECA.Events
{
    [CreateAssetMenu(menuName = ContextMenuPath.ECA + "Event")]
    public class ScriptableEvent : ScriptableObject
    {
        private List<ScriptableEventListener> _listeners = new ();

        private List<Action> _callbacks = new ();

        public void RegisterListener(ScriptableEventListener listener)
        {
            _listeners ??= new List<ScriptableEventListener>();
            _listeners.Add(listener);
        }

        public void UnregisterListener(ScriptableEventListener listener)
        {
            _listeners.Remove(listener);
        }

        public void RegisterListener(Action callback)
        {
            _callbacks ??= new List<Action>();
            _callbacks.Add(callback);
        }

        public void UnregisterListener(Action callback)
        {
            _callbacks.Remove(callback);
        }

        public void Raise()
        {
            for (int i = 0, length = _listeners.Count; i < length; ++i)
            {
                _listeners[i].RaiseEvent();
            }

            for (int i = 0, length = _callbacks.Count; i < length; ++i)
            {
                _callbacks[i]?.Invoke();
            }
        }

        [Button]
        private void ClearAllListeners()
        {
            _listeners.Clear();
            _callbacks.Clear();
        }
    }
}
