﻿using System.Collections.Generic;
using UnityEngine;

namespace UnityTools.Runtime.Lists
{
    public abstract class ListVariable<T> : ScriptableObject, IListVariable
    {
        [SerializeField]
        private List<T> _items;

        public IReadOnlyList<T> Items => _items;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public T Get(int index)
        {
            return Items.Count > index ? Items[index] : default;
        }
        
        public void Clear()
        {
            _items.Clear();
        }
    }
}