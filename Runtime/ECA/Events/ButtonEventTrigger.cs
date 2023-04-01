using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UnityTools.Runtime.ECA.Events
{
    [RequireComponent(typeof(Button))]
    public class ButtonEventTrigger : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEvent _event;
        
        private void Awake()
        {
            var button = GetComponent<Button>();
            button.OnClickAsObservable().Subscribe(_ => _event.Raise());
        }
    }
}