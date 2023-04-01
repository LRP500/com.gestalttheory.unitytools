using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    [CreateAssetMenu(menuName = ContextMenuPath.Variables + "Camera")]
    public class CameraVariable : Variable<Camera>
    {
        [Button]
        [EnableIf("@Value != null && !Value.enabled")]
        public void Render()
        {
            Value.Render();
        }
     }
}