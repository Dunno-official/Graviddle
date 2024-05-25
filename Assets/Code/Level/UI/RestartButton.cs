using Character;
using UnityEngine;
using UnityEngine.UI;

namespace Level.UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private readonly EventTransit _eventTransit = new EventTransit();


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