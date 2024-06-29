using System.Collections.Generic;
using Level.CharacterNM;
using UnityEngine;

namespace Level.AnalyticsNM
{
    public class DeathAnalytics
    {
        private readonly CharacterDeathConditions _deathConditions;
        private readonly List<string> _deathReasons = new();
        private readonly int _deathCountPerRequest;
        private readonly Screenshot _screenshot;

        public DeathAnalytics(int deathCountPerRequest, CharacterDeathConditions deathConditions)
        {
            _screenshot = new Screenshot(new Vector2Int(Screen.width, Screen.height) / 2);
            _deathCountPerRequest = deathCountPerRequest;
            _deathConditions = deathConditions;
        }

        public int DeathCount { get; private set; }

        public async void Update()
        {
            DeathCount++;
            _deathReasons.Add(_deathConditions.Reason);
            
            if (DeathCount % _deathCountPerRequest == 0)
            {
                byte[] data = await _screenshot.MakeScreenshot();
            }
        }
    }
}