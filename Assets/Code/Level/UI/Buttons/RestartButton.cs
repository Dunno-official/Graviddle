using Level.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Level.UI.Buttons
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private readonly PollingEvent _eventTransit = new();

        private void Start()
        {
            _button.onClick.AddListener(_eventTransit.Invoke);
        }
    
        public bool CheckIfPressed()
        {
            return _eventTransit.CheckIfEventHappened();
        }
    }
}