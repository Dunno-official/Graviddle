using Level.CharacterNM.CharacterStateMachineNM.States;
using Level.UserInterface.Panels.WinPanel;
using MonoBehaviourWrapperNM;
using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level.AnalyticsNM
{
    public class Analytics : ISubscriber, IInitializable
    {
        private readonly LevelRecordPostRequest _postRequest = new();
        private readonly ISaveLoadSystem _saveLoadSystem;
        private readonly WinState _winState;
        private readonly DieState _dieState;
        private readonly Reward _reward;
        private float _startTime;
        private int _deathCount;

        public Analytics(ISaveLoadSystem saveLoadSystem, WinState winState, DieState dieState, Reward reward)
        {
            _saveLoadSystem = saveLoadSystem;
            _winState = winState;
            _dieState = dieState;
            _reward = reward;
        }

        public void Initialize()
        {
            _startTime = Time.time;
        }

        public void Subscribe()
        {
            _winState.Entered += OnWin;
            _dieState.Entered += OnDied;
        }

        public void Unsubscribe()
        {
            _winState.Entered -= OnWin;
            _dieState.Entered -= OnDied;
        }

        private void OnDied()
        {
            _deathCount++;
        }

        private void OnWin()
        {
            _postRequest.Execute(new LevelRecord()
            {
                DeviceId = SystemInfo.deviceUniqueIdentifier,
                Name = "Denys",
                DeathCount = _deathCount,
                Level = SceneManager.GetActiveScene().name,
                Stars = _reward.CollectedStars,
                Time = Time.time - _startTime
            });
        }
    }
}