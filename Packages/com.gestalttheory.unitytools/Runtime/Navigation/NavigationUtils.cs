using UnityEngine;

namespace UnityTools.Runtime.Navigation
{
    public static class NavigationUtils
    {
        public static void Quit()
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif
 
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}