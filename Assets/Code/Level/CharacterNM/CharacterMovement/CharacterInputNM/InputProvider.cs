using Level.Gravitation;
using Level.UI.Panels.GameplayPanel.MovementButtons;
using UnityEngine;

namespace Level.CharacterNM.CharacterMovement.CharacterInputNM
{
    public class InputProvider
    {
        private readonly IGravityState _gravityState;
        private readonly InputButton _rightButton;
        private readonly InputButton _leftButton;

        public InputProvider(InputButton leftButton, InputButton rightButton, IGravityState gravityState)
        {
            _gravityState = gravityState;
            _rightButton = rightButton;
            _leftButton = leftButton;
        }

        public CharacterInput GetInput()
        {
            CharacterInput baseInput = Application.isEditor ? new DesktopInput() : new MobileInput(_leftButton, _rightButton);

            return new GravityInput(_gravityState, baseInput);
        }
    }
}