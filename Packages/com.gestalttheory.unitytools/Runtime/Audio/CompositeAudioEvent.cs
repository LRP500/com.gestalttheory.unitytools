using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace UnityTools.Runtime.Audio
{
    [CreateAssetMenu(menuName = ContextMenuPath.Audio + "Composite Audio Event")]
    public class CompositeAudioEvent : AudioEvent
    {
        [Serializable]
        private struct Item
        {
            public AudioEvent @event;
            public float weight;
        }

        private Item[] _items;

        public override void Play(AudioSource source)
        {
            float totalWeight = 0;
            for (var i = 0; i < _items.Length; ++i)
            {
                totalWeight += _items[i].weight;
            }

            var pick = Random.Range(0, totalWeight);
            for (var i = 0; i < _items.Length; ++i)
            {
                if (pick > _items[i].weight)
                {
                    pick -= _items[i].weight;
                    continue;
                }

                _items[i].@event.Play(source);
                break;
            }
        }
    }
}