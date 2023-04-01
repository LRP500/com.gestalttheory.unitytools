using System;
using System.Globalization;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.Time
{
    public class TimeManager : Singleton<TimeManager>
    {
        private static readonly ISubject<float> _onUpdateTick = new Subject<float>();
        public static IObservable<float> OnUpdateTick => _onUpdateTick;

        [SerializeField]
        private bool _live = true;

        [SerializeField]
        [EnableIf(nameof(_live))]
        private float _tickInterval = 1f;

        [SerializeField]
        [EnableIf(nameof(_live))]
        private bool _unscaledTick;
        
        [Header("Current State")]

        [ReadOnly]
        [HideInEditorMode]
        public string _timeScale = string.Empty;

        [ReadOnly]
        [HideInEditorMode]
        public string _speedMultiplier = string.Empty;

        private float _frameDelta;
        private float _tickDelta;

        private float _lastSpeedMultiplier;
        private float _lastFrameTime;
        private float _lastTickTime;
        private float _timer;
        
        private readonly BoolReactiveProperty _gamePaused = new();
        public IReadOnlyReactiveProperty<bool> GamePaused => _gamePaused;
        
        public float SpeedMultiplier { get; private set; } = 1;

        protected override void Initialize()
        {
            SetSpeedMultiplier(1);
            _timer = _tickInterval;
            _lastTickTime = GetTime();
            _lastFrameTime = GetTime();
            _gamePaused.Value = false;
        }
        
        protected virtual void Update()
        {
            if (_live)
            {
                _frameDelta = GetTime() - _lastFrameTime;
                _lastFrameTime = GetTime();

                if (_gamePaused.Value == false)
                {
                    _timer += _frameDelta * SpeedMultiplier;
                    if (_timer >= _tickInterval)
                    {
                        TickUpdate();
                        _timer = 0;
                    }
                }
            }

            _timeScale = UnityEngine.Time.timeScale.ToString(CultureInfo.InvariantCulture);
            _speedMultiplier = SpeedMultiplier.ToString(CultureInfo.InvariantCulture);
        }

        protected virtual void TickUpdate()
        {
            var currentTime = GetTime();
            _tickDelta = currentTime - _lastTickTime;
            _lastTickTime = currentTime;
            
            _onUpdateTick.OnNext(_tickDelta);
        }

        public virtual void Pause()
        {
            UnityEngine.Time.timeScale = 0;
            _gamePaused.Value = true;
        }

        public virtual void Resume()
        {
            UnityEngine.Time.timeScale = SpeedMultiplier;
            _gamePaused.Value = false;
        }

        public void TogglePause()
        {
            if (_gamePaused.Value) Resume();
            else Pause();
        }
        
        public virtual void SetSpeedMultiplier(float multiplier)
        {
            _lastSpeedMultiplier = SpeedMultiplier;
            SpeedMultiplier = multiplier;
        }

        private float GetTime()
        {
            return _unscaledTick ? UnityEngine.Time.realtimeSinceStartup : UnityEngine.Time.time;
        }

        public void Freeze()
        {
            SetSpeedMultiplier(0);
        }

        public void Unfreeze()
        {
            SetSpeedMultiplier(_lastSpeedMultiplier);
        }
    }
}