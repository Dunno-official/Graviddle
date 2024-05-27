using Level.UserInterface.Panels.GameplayPanel.MovementButtons;
using UnityEngine;

namespace Level.Tutorial
{
    public class TutorialButtons : MonoBehaviour
    {
        [SerializeField] private StoryTelling _storyTelling;
        [SerializeField] private InputButton _leftButton;
        [SerializeField] private InputButton _rightButton;

        private void OnEnable()
        {
            _storyTelling.StoryEnded += OnStoryEnded;
        }
    
        private void OnDisable()
        {
            _storyTelling.StoryEnded -= OnStoryEnded;
        }

        private void OnStoryEnded()
        {
            _leftButton.gameObject.SetActive(true);
            _rightButton.gameObject.SetActive(true);
        }
    }
}