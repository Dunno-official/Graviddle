using System;
using System.Collections.Generic;
using Level.AnalyticsNM.RequestNM;
using Level.CharacterNM;
using SaveSystem;
using Unity.Collections;
using UnityEngine.SceneManagement;

namespace Level.AnalyticsNM
{
    public class DeathAnalytics
    {
        private readonly CharacterDeathConditions _deathConditions;
        private readonly List<string> _deathReasons = new();
        private readonly int _deathCountPerRequest;
        private readonly Screenshot _screenshot;
        private readonly PostRequest _request;

        public DeathAnalytics(CharacterDeathConditions deathConditions)
        {
            _screenshot = new Screenshot(scale:0.25f);
            _deathConditions = deathConditions;
            _request = Requests.DeathRecord;
            _deathCountPerRequest = 3;
        }

        public int DeathCount { get; private set; }

        public async void Update()
        {
            DeathCount++;
            _deathReasons.Add(_deathConditions.Reason);
            
            if (DeathCount % _deathCountPerRequest == 0)
            {
                NativeArray<byte> data = await _screenshot.MakeScreenshotPNG();
                
                await _request.Send(new DeathRecord()
                {
                    Name = new UserName().Load(),
                    Level = SceneManager.GetActiveScene().name,
                    Reasons = _deathReasons.ToArray(),
                    ScreenShot = Convert.ToBase64String(data)
                });

                data.Dispose();
            }
        }
    }
}