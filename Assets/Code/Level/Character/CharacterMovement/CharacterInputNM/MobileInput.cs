using Level.UI.Panels.GameplayPanel.MovementButtons;
using UnityEngine;

namespace Level.Character.CharacterMovement.CharacterInputNM
{
    public class MobileInput : CharacterInput
    {
        private readonly InputButton _leftButton;
        private readonly InputButton _rightButton;

        public MobileInput(InputButton leftButton, InputButton rightButton)
        {
            _leftButton = leftButton;
            _rightButton = rightButton;
        }
        
        public override Vector2 GetDirection()
        {
            Vector2 result = Vector2.zero;
            
            if (_leftButton.IsTouching)
            {
                result = new Vector2(-1, 0);
            }
            
            if (_rightButton.IsTouching)
            {
                result = new Vector2(1, 0);
            }

            return result;
        }
    }
}