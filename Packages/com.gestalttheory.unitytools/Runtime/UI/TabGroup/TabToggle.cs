using UnityEngine;
using UnityEngine.UI;

namespace UnityTools.Runtime.UI
{
    /// <summary>
    /// UI tab toggle to be used in conjunction with TabGroup
    /// </summary>
    public class TabToggle : MonoBehaviour
    {
        /// <summary>
        /// Reference to the UI.Toggle
        /// </summary>
        public Toggle Toggle { get; private set; }
        
        private void Awake()
        {
            Toggle = GetComponent<Toggle>();
        }
    }
}