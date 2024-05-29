using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace SaveSystem
{
    public class PlayerProgress
    {
        private readonly string _progressKey = "Saves_1";
        private readonly ISaveLoadSystem _saveLoadSystem;
        private Dictionary<int, int> _saves;
        
        public PlayerProgress()
        {
            _saveLoadSystem = new PrefsSaveLoadSystem();
        }

        public int FinishedLevels => _saves.Count;

        public void Initialize()
        {
            _saves = _saveLoadSystem.HasKey(_progressKey)
                ? _saveLoadSystem.Load<Dictionary<int, int>>(_progressKey)
                : new Dictionary<int, int>();
        }
        
        public void SetStarsForCurrentScene(int numOfStars)
        {
            _saves[SceneManager.GetActiveScene().buildIndex] = numOfStars;
            _saveLoadSystem.Save(_progressKey, _saves);
        }

        public int GetStarsForLevel(int levelIndex)
        {
            return _saves.TryGetValue(levelIndex, out int save) ? save : 0;
        }
    }
}