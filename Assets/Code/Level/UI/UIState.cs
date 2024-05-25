using Level.UI.Switchers;
using UnityEngine;

namespace Level.UI
{
    public class UIState : MonoBehaviour
    {
        [SerializeField] private UIStatesSwitcher _uiStatesSwitcher;


        public void Activate()
        {
            _uiStatesSwitcher.ActivateState(this);
        }
    }
}