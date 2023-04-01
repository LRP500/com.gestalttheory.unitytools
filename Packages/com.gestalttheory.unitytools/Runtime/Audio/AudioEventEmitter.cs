using UnityEngine;

namespace UnityTools.Runtime.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioEventEmitter : MonoBehaviour
    {
        [SerializeField]
        private AudioEvent _event;

        [SerializeField]
        private bool _playOnAwake;
        
        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            
            if (_playOnAwake)
            {
                Play();
            }
        }

        public void Play()
        {
            _event.Play(_source);
        }
    }
}