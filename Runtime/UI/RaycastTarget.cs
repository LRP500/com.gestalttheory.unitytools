using UnityEngine;
using UnityEngine.UI;

namespace UnityTools.Runtime.UI
{
    /// <summary>
    /// Provides a raycast target without actually drawing anything.
    /// </summary>
    [RequireComponent(typeof(CanvasRenderer))]
    public class RaycastTarget : Graphic
    {
        public override void SetMaterialDirty() { }
        public override void SetVerticesDirty() { }
     
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
}