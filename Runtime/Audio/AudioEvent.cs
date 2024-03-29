﻿using UnityEngine;

namespace UnityTools.Runtime.Audio
{
    public abstract class AudioEvent : ScriptableObject
    {
        public abstract void Play(AudioSource source);
    }
}