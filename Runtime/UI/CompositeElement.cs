using UnityEngine;

namespace UnityTools.Runtime.UI
{
    public class CompositeElement : Element
    {
        [SerializeField]
        private Element[] _children;

        protected override void OnShow()
        {
            foreach (var child in _children)
            {
                child.Show();
            }
        }
        
        protected override void OnHide()
        {
            foreach (var child in _children)
            {
                child.Hide();
            }
        }

        public override void Refresh()
        {
            foreach (var child in _children)
            {
                child.Refresh();
            }
        }
    }
}