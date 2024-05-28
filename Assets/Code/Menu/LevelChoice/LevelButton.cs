using Extensions;
using Level.UserInterface.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.LevelChoice
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private SceneTransitButton _sceneTransitButton;
        [SerializeField] private TMP_Text _levelIndex;
        [SerializeField] private Image[] _nonStars;
        [SerializeField] private Image _lockImage;
        [SerializeField] private Image[] _stars;
        [SerializeField] private Button _button;

        public void Initialize(UIBlocker uiBlocker, int levelIndex, int numOfStars, bool isUnlocked)
        {
            _levelIndex.text = (levelIndex + 1).ToString();
            _button.onClick.AddListener(uiBlocker.Enable);
            SetStars(numOfStars);

            if (isUnlocked)
            {
                UnlockLevel();
            }

            _sceneTransitButton.SetTransitSceneIndex(levelIndex);
        }

        private void SetStars(int stars)
        {
            _nonStars.ForEach(nonStar => nonStar.gameObject.SetActive(true));
        
            for (int i = 0; i < stars; i++)
            {
                _stars[i].gameObject.SetActive(true);
                _nonStars[i].gameObject.SetActive(false);
            }
        }

        private void UnlockLevel()
        {
            _lockImage.gameObject.SetActive(false);
            _button.interactable = true;
        }
    }
}