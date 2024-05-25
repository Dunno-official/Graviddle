using UnityEngine;

namespace Level.UI
{
    public class TimeScaleSwitcher : MonoBehaviour
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

