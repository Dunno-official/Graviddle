using Level.UserInterface.Panels.WinPanel;
using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using SystemInfo = UnityEngine.Device.SystemInfo;

namespace Level.AnalyticsNM
{
    public class LevelAnalytics
    {
        private readonly LevelRecordPostRequest _postRequest = new();
        private readonly DeathAnalytics _deathAnalytics;
        private readonly float _startTime;
        private readonly Reward _reward;

        public LevelAnalytics(DeathAnalytics deathAnalytics, Reward reward, float startTime)
        {
            _deathAnalytics = deathAnalytics;
            _startTime = startTime;
            _reward = reward;
        }

        public void PostRecord()
        {
            float timeForLevel = Time.time - _startTime;
            
            _postRequest.Execute(new LevelRecord()
            {
                Id = SystemInfo.deviceUniqueIdentifier,
                Name = new UserName().Load(),
                DeathCount = _deathAnalytics.DeathCount,
                Level = SceneManager.GetActiveScene().name,
                Stars = _reward.CollectedStars,
                Time = Mathf.Round(timeForLevel * 100f) / 100f
            });
        }
    }
}