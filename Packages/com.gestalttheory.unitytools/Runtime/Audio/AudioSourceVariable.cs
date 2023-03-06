using UnityEngine;
using UnityTools.Runtime.Variables;

namespace UnityTools.Runtime.Audio
{
    [CreateAssetMenu(menuName = ContextMenuPath.Audio + "Audio Source Variable")]
    public class AudioSourceVariable : Variable<AudioSource>
    {
    }
}