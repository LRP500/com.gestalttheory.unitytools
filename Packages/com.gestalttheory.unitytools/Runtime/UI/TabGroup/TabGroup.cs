using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Extensions;

namespace UnityTools.Runtime.UI
{
    /// <summary>
    /// Manages a collection of UI tab pairs
    /// </summary>
    public class TabGroup : MonoBehaviour
    {
        #region Serialized Fields

        /// <summary>
        /// The first tab to be selected on group enabled
        /// </summary>
        [SerializeField]
        private TabToggle _firstSelectedTab;
        
        /// <summary>
        /// All tab pairs to be managed by tab group
        /// </summary>
        [SerializeField]
        private List<TabPair> _tabPairs;
        
        #endregion Serialized Fields

        /// <summary>
        /// The index of the currently selected tab pair
        /// </summary>
        private int? _currentTabIndex;

        #region Private Methods

        private void Start()
        {
            for (var i = 0; i < _tabPairs.Count; i++)
            {
                var pair = GetPairAt(i);
                pair?.tab.Toggle.onValueChanged
                    .AsObservable()
                    .Where(x => x)
                    .Subscribe(_ => Select(pair));
            }
        }

        private void OnEnable()
        {
            // Initialize all tabs to an unselected state
            for (var i = 0; i < _tabPairs.Count; i++)
            {
                SetTabState(i, false);
            }
            
            // Select the default tab
            if (_tabPairs.Count <= 0 || !_firstSelectedTab) return;
            var index = FindTabIndex(_firstSelectedTab) ?? 0;
            Select(index);
        }
        
        /// <summary>
        /// Selects pair with given toggle reference
        /// </summary>
        /// <param name="pair"></param>
        protected virtual void Select(TabPair pair)
        {
            int? index = FindTabIndex(pair.tab);
            
            if (index.HasValue)
            {
                Select(index.Value);
            }
        }
        
        /// <summary>
        /// Sets new selected state for tab at given index 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="selected"></param>
        protected virtual void SetTabState(int index, bool selected)
        {
            var tab = GetPairAt(index);

            if (tab?.content != null && tab.tab != null)
            {
                tab.content.Toggle(selected);
            }
        }
        
        /// <summary>
        /// Returns index of given tab it it exists, else returns null
        /// </summary>
        /// <param name="toggle"></param>
        /// <returns></returns>
        private int? FindTabIndex(TabToggle toggle)
        {
            var currentTabPair = _tabPairs.FirstOrDefault(x => x.tab == toggle);

            if (currentTabPair != default)
            {
                return _tabPairs.IndexOf(currentTabPair);
            }
            
            Debug.LogError($"Tab {toggle.gameObject.name} does not belong to tab group {name}");
            return null;
        }

        /// <summary>
        /// Returns the tab at index if it exists, else returns false
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [CanBeNull]
        private TabPair GetPairAt(int index)
        {
            return index.InRange(0, _tabPairs.Count) ? _tabPairs[index] : null;
        }
        
        #endregion Private Methods

        #region Public Methods
        
        /// <summary>
        /// Selects tab at given index
        /// </summary>
        /// <param name="index"></param>
        public void Select(int index)
        {
            if (_currentTabIndex == index) return;

            if (_currentTabIndex.HasValue)
            {
                SetTabState(_currentTabIndex.Value, false);
            }

            _currentTabIndex = index;
            SetTabState(_currentTabIndex.Value, true);
        }
        
        /// <summary>
        /// Adds a listener on value changed for callback at given index 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="callback"></param>
        public void SetTabCallback(int index, Action<bool> callback)
        {
            GetPairAt(index)?.tab.Toggle.onValueChanged
                .AddListener(x => callback?.Invoke(x));
        }

        #endregion Public Methods
    }
}