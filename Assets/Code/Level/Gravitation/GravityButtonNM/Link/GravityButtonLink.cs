using System.Linq;
using Extensions;
using UnityEngine;

namespace Level.Gravitation.GravityButtonNM.Link
{
    public abstract class GravityButtonLink : MonoBehaviour
    {
        [SerializeField] private GravityButton[] _gravityButtons;
        [SerializeField] private bool _reverseInput;
        
        private void OnEnable()
        {
            _gravityButtons.ForEach(x => x.Events.Toggled += OnButtonToggled);
        }
    
        private void OnDisable()
        {
            _gravityButtons.ForEach(x => x.Events.Toggled -= OnButtonToggled);
        }
        
        private void OnButtonToggled(bool buttonEnabled)
        {
            bool isAllButtonsEnabled = _gravityButtons.All(x => x.State.IsEnabled);
            bool isEnabled = _reverseInput ? !isAllButtonsEnabled : isAllButtonsEnabled;
        
            if (isEnabled)
            {
                Enable();
            }
            else
            {
                Disable();
            }
        }

        protected abstract void Enable();
        protected abstract void Disable();
    }
}