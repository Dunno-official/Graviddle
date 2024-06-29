using Level.CharacterNM;
using UnityEngine;
using UnityEngine.UI;

namespace Level.UserInterface.Buttons
{
    public class RestartButton : MonoBehaviour, IDeathCondition
    {
        [SerializeField] private Button _button;
        private readonly PollingEvent _eventTransit = new();

        private void Start()
        {
            _button.onClick.AddListener(_eventTransit.Invoke);
        }

        public bool IsDead(out string reason)
        {
            reason = "Manual restart";
            return _eventTransit.IsTrue();
        }
    }
}