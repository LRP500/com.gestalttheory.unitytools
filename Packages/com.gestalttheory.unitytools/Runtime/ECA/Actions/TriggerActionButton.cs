using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityTools.Runtime.Extensions;

namespace UnityTools.Runtime.ECA.Actions
{
    [RequireComponent(typeof(Button))]
    public class TriggerActionButton : MonoBehaviour
    {
        [SerializeField]
        private ScriptableAction _action;

        private Button _button;
        
        private void OnEnable()
        {
            _button ??= GetComponent<Button>();
            _button.interactable = _action.CanExecute();
            _button.OnClickAsObservable()
                .Subscribe(_ => OnClick())
                .AddToDisable(this);
        }

        private void OnClick()
        {
            _action.Execute();
        }
    }
}
