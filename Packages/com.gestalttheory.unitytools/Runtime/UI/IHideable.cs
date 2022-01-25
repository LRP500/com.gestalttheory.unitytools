namespace UnityTools.Runtime.UI
{
    public interface IHideable
    {
        void Show();
        void Hide();
        void Toggle(bool opened);
    }
}