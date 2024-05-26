using Level.Gravitation.GravityButton;
using UnityEngine;

namespace Level.DoorNM
{
    public class DoorButtonLink : MonoBehaviour
    {
        [SerializeField] private GravityButton _gravityButton;
        [SerializeField] private bool _reverseInput;
        [SerializeField] private Door _door;

        private void OnEnable()
        {
            _gravityButton.Toggled += OnButtonToggled;
        }
    
        private void OnDisable()
        {
            _gravityButton.Toggled -= OnButtonToggled;
        }

        private void OnButtonToggled(bool buttonEnabled)
        {
            buttonEnabled = _reverseInput ? !buttonEnabled : buttonEnabled;
        
            if (buttonEnabled)
            {
                _door.Open();
            }
            else
            {
                _door.Close();
            }
        }
    }
}