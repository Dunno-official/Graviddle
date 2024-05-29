using Cysharp.Threading.Tasks;
using DefaultNamespace;
using Menu.MainMenu.AnimatedPanel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.LevelChoice
{
    public class LevelChoicePanel : AnimatedPanel
    {
        [SerializeField] private LevelButton _levelButtonPrefab;
        [SerializeField] private GridLayoutGroup _levelsGrid;
        private readonly int _numOfNonLevelScenes = 1;
        
        public override UniTask Initialize()
        {
            PlayerProgress playerProgress = new();
            
            playerProgress.Initialize();
            int numOfLevels = GetNumOfLevels();
            InitializeLevelButtons(numOfLevels, playerProgress);

            return base.Initialize();
        }

        private int GetNumOfLevels()
        {
            int numOfLevels = SceneManager.sceneCountInBuildSettings - _numOfNonLevelScenes;
            return numOfLevels;
        }

        private void InitializeLevelButtons(int numOfLevels, PlayerProgress playerProgress)
        {
            for (int levelIndex = _numOfNonLevelScenes; levelIndex <= numOfLevels; ++levelIndex)
            {
                LevelButton levelButton = Instantiate(_levelButtonPrefab, _levelsGrid.transform);
                bool isUnlocked = levelIndex <= playerProgress.FinishedLevels;
                int starsForLevel = playerProgress.GetStarsForLevel(levelIndex);

                levelButton.Initialize(UIBlocker, levelIndex, starsForLevel, isUnlocked);
            }
        }
    }
}