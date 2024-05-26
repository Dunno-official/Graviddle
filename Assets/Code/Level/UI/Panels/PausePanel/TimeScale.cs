using UnityEngine;

namespace Level.UI.Panels.PausePanel
{
    public class TimeScale
    {
        public void FreezeGame()
        {
            SetTimeScale(0);
        }

        public void UnfreezeGame()
        {
            SetTimeScale(1);
        }

        private void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}

