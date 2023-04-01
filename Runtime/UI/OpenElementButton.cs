using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UnityTools.Runtime.UI
{
    [RequireComponent(typeof(Button))]
    public class OpenElementButton : MonoBehaviour
    {
        [SerializeField]
        private Element _element;

        private void Awake()
        {
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => _element.Show())
                .AddTo(gameObject);
        }
    }
}