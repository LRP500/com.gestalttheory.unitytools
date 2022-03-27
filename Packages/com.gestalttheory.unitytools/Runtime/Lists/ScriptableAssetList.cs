﻿using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityTools.Runtime.Lists
{
    public abstract class ScriptableAssetList<T> : ScriptableObject where T : class
    {
        [AssetList]
        [SerializeField]
        private List<T> _items;

        public IReadOnlyList<T> Items => _items;

        public T Get(int index)
        {
            return Items.Count > index ? Items[index] : null;
        }
    }
}