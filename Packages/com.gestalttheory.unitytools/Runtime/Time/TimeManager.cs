using System.Globalization;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityTools.Runtime.Variables;

namespace UnityTools.Runtime.Time
{
    public class TimeManager : Singleton<TimeManager>
    {
        public static ISubject<float> OnUpdateTick = new Subject<float>();
        
        [SerializeField]
        private bool _live = true;

        [SerializeField]
        [EnableIf(nameof(_live))]
        private float _tickInterval = 1f;

        [SerializeField]
        [EnableIf(nameof(_live))]
        private bool _unscaledTick;

        [SerializeField]
        private BoolReactiveVariable _gamePaused;

        [SerializeField]
        private TimeManagerVariable _runtimeReference;
        
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

        public float SpeedMultiplier { get; private set; } = 1;

        public IReadOnlyReactiveProperty<bool> GamePaused => _gamePaused.Property;
        
        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }

        private void Initialize()
        {
            SetSpeedMultiplier(1);
            _timer = _tickInterval;
            _lastTickTime = GetTime();
            _lastFrameTime = GetTime();
            _runtimeReference.SetValue(this);
        }
        
        protected virtual void Update()
        {
            if (_live)
            {
                _frameDelta = GetTime() - _lastFrameTime;
                _lastFrameTime = GetTime();

                if (_gamePaused == false)
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

        protected virtual void OnDestroy()
        {
            OnUpdateTick = null;
        }

        protected virtual void TickUpdate()
        {
            float currentTime = GetTime();
            _tickDelta = currentTime - _lastTickTime;
            _lastTickTime = currentTime;
            
            OnUpdateTick.OnNext(_tickDelta);
        }

        public virtual void Pause()
        {
            UnityEngine.Time.timeScale = 0;
            _gamePaused.SetValue(true);
        }

        public virtual void Resume()
        {
            UnityEngine.Time.timeScale = SpeedMultiplier;
            _gamePaused.SetValue(false);
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