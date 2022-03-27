namespace UnityTools.Runtime.UI
{
    /// <summary>
    /// Defines a pair to UI tab toggle and its target to be used in conjunction with TabGroup
    /// </summary>
    [System.Serializable]
    public class TabPair
    {
        public TabToggle tab;
        public Element content;
    }
}