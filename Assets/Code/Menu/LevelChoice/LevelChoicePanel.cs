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
        
        public override UniTask Initialize()
        {
            PlayerProgress playerProgress = new();
            
            playerProgress.Initialize();
            int numOfLevels = GetNumOfLevels();
            InitializeLevelButtons(numOfLevels, playerProgress);

            return base.Initialize();
        }

        private static int GetNumOfLevels()
        {
            const int numOfNonLevelScenes = 1;
            int numOfLevels = SceneManager.sceneCountInBuildSettings - numOfNonLevelScenes;
            return numOfLevels;
        }

        private void InitializeLevelButtons(int numOfLevels, PlayerProgress playerProgress)
        {
            for (int levelIndex = 0; levelIndex < numOfLevels; ++levelIndex)
            {
                LevelButton levelButton = Instantiate(_levelButtonPrefab, _levelsGrid.transform);
                bool isUnlocked = levelIndex <= playerProgress.FinishedLevels;
                int starsForLevel = playerProgress.GetStarsForLevel(levelIndex);

                levelButton.Initialize(UIBlocker, levelIndex, starsForLevel, isUnlocked);
            }
        }
    }
}