using Level.AnalyticsNM.RequestNM;
using Level.UserInterface.Panels.WinPanel;
using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using SystemInfo = UnityEngine.Device.SystemInfo;

namespace Level.AnalyticsNM
{
    public class LevelAnalytics
    {
        private readonly DeathAnalytics _deathAnalytics;
        private readonly PostRequest _postRequest;
        private readonly float _startTime;
        private readonly Reward _reward;

        public LevelAnalytics(DeathAnalytics deathAnalytics, Reward reward, float startTime)
        {
            _postRequest = Requests.LevelRecord;
            _deathAnalytics = deathAnalytics;
            _startTime = startTime;
            _reward = reward;
        }

        public async void PostRecord()
        {
            float timeForLevel = Time.time - _startTime;
            
            await _postRequest.Send(new LevelRecord()
            {
                Id = SystemInfo.deviceUniqueIdentifier,
                Name = new UserName().Load(),
                DeathCount = _deathAnalytics.DeathCount,
                Level = SceneManager.GetActiveScene().name,
                LevelIndex = SceneManager.GetActiveScene().buildIndex,
                Stars = _reward.CollectedStars,
                Time = Mathf.Round(timeForLevel * 100f) / 100f
            });
        }
    }
}